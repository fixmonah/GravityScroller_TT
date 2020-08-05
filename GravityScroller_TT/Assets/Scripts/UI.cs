using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _uiMenu;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Toggle _soundToggle;
    
    [Space] 
    [SerializeField] private GameObject _uiGame;
    [SerializeField] private Text _gameScoreText;

    private string _soundKey = "sound";

    private void Start()
    {
        ShowMainUI();
    }

    public void ShowMainUI()
    {
        _uiMenu.SetActive(true);
        LoadSoundSettings();
        
        if (GameController.instance != null)
        {
            _bestScoreText.text = String.Format($"Best score: {GameController.instance.GetBestScore()}");
        }

        if (GameController.instance != null)
        {
            _scoreText.text = String.Format($"Score: {GameController.instance.GetScore()}");
        }
    }

    public void HideMainUI()
    {
        _uiMenu.SetActive(false);
    }

    public void ShowGameUI()
    {
        _uiGame.SetActive(true);   
    }

    public void HideGameUI()
    {
        _uiGame.SetActive(false);   
    }

    public void SaveSoundSettings()
    {
        int toggleState = 0;
        if (_soundToggle.isOn)
        {
            toggleState = 1;
        }
        else
        {
            toggleState = -1;
        }
        PlayerPrefs.SetInt(_soundKey, toggleState);
        GameController.instance.GetAudioController().SoundMute(_soundToggle.isOn);
    }

    public void LoadSoundSettings()
    {
        int toggleState = PlayerPrefs.GetInt(_soundKey);
        if (toggleState > 0)
        {
            _soundToggle.isOn = true;
        }
        else
        {
            _soundToggle.isOn = false;
        }
        GameController.instance.GetAudioController().SoundMute(_soundToggle.isOn);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void UpdateScoreText()
    {
        if (GameController.instance != null && _uiGame.activeSelf == true)
        {
            _gameScoreText.text = String.Format($" Score: {GameController.instance.GetScore()}");
        }
    }

    private void Update()
    {
        UpdateScoreText();
    }


}