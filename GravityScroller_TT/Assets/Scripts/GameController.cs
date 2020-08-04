using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singletone

    public static GameController instance = null;

    void Start () {
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
    [SerializeField] private GameObject _platformSpawnPoint;
    [SerializeField] private PlatformsPool _platformsPool;
    
    [Header("Game settings")]
    [SerializeField] private int _gravityValue = 20;
    private bool _gravityUp = false;
    [SerializeField] private float _moveSpeed = 0.1f;
    
    private void InitializeManager(){ }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    private void ChangeGravity()
    {
        if (_gravityUp)
        {
            _background.ChangeSpriteOn(BackgroundType.Up);
            Physics.gravity = new Vector3(0, _gravityValue, 0);
        }
        else
        {
            _background.ChangeSpriteOn(BackgroundType.Down);
            Physics.gravity = new Vector3(0, _gravityValue * -1, 0);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gravityUp = !_gravityUp;
            ChangeGravity();
        }
    }

    public void PlatformHide()
    {
        GameObject newPlatform = _platformsPool.GetPrefab();
        newPlatform.transform.position = _platformSpawnPoint.transform.position;
        newPlatform.SetActive(true);
    }
}
