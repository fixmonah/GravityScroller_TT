using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singletone

    public static GameController instance = null;

    void Awake () {
        if (instance == null) {
            instance = this;
        } else if(instance == this){
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    #endregion


    [Header("Game Objects")]
    [SerializeField] private Background _background;
    [SerializeField] private Transform _platformSpawnPoint;
    [SerializeField] private PlatformsPool _platformsPool;
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _ballStartPosition;
    [SerializeField] private UI _ui;
    [SerializeField] private AudioController _audioController;
    
    [Header("Game settings")]
    [SerializeField] private int _gravityValue = 20;
    [SerializeField] private int _gravityValueDefault = 20;
    private bool _gravityUp = false;
    [SerializeField] private float _moveSpeed = 0.1f;
    [SerializeField] private float _moveSpeedDefault = 0.1f;
    [SerializeField] private float _moveSpeedFactor = 0.1f;

    private DateTime _dateTimeStartGame;
    private int _score = 0;
    private bool _isStartGame;
    private string _keyForKeyCode = "bestScore";
    
    private void InitializeManager(){ }


    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    public bool GameIsStarted()
    {
        return _isStartGame;
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(_keyForKeyCode);
    }

    public AudioController GetAudioController()
    {
        return _audioController;
    }

    public void StartGame()
    {
        GetAudioController().Play(AudioControllerTrack.StartGame);
        _dateTimeStartGame = DateTime.Now;
        _gravityValue = _gravityValueDefault;
        _moveSpeed = _moveSpeedDefault;
        _ball.transform.position = _ballStartPosition.position;
        _ball.StartGame();
        _isStartGame = true;
        _ui.HideMainUI();
        _ui.ShowGameUI();
    }

    public void EndGame()
    {
        GetAudioController().Play(AudioControllerTrack.EndGame);
        _isStartGame = false;
        _ball.transform.position = _ballStartPosition.position;
        _ball.EndGame();
        SaveBestScore();
        _ui.HideGameUI();
        _ui.ShowMainUI();
    }

    private void CalculateScore()
    {
        if (_isStartGame)
        {
            double seconds = (DateTime.Now - _dateTimeStartGame).TotalSeconds;
            _score = (int)(Math.Round(seconds, 1) * 10);
        }
    }

    public void SaveBestScore()
    {
        int bestScore = PlayerPrefs.GetInt(_keyForKeyCode);
        if (bestScore < _score || bestScore == null)
        {
            PlayerPrefs.SetInt(_keyForKeyCode,_score);
        }
    }

    private void CalculateSpeed()
    {
        if (_isStartGame)
        {
            _moveSpeed = _moveSpeedDefault * _moveSpeedFactor * _score;
        }
    }

    private void ChangeGravity()
    {
        if (_gravityUp)
        {
            GetAudioController().Play(AudioControllerTrack.GravityUp);
            _background.ChangeSpriteOn(BackgroundType.Up);
            Physics.gravity = new Vector3(0, _gravityValue, 0);
        }
        else
        {
            GetAudioController().Play(AudioControllerTrack.GravityDown);
            _background.ChangeSpriteOn(BackgroundType.Down);
            Physics.gravity = new Vector3(0, _gravityValue * -1, 0);
        }
    }

    private void Update()
    {
        CalculateScore();
        CalculateSpeed();
        if (Input.GetMouseButtonDown(0) && _isStartGame)
        {
            _gravityUp = !_gravityUp;
            ChangeGravity();
        }
    }

    public void PlatformHide()
    {
        GameObject newPlatform = _platformsPool.GetPrefab();
        newPlatform.transform.position = _platformSpawnPoint.position;
        newPlatform.SetActive(true);
    }
}
