using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Sprite _default;
    [SerializeField] private Sprite _down;
    [SerializeField] private Sprite _up;

    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSpriteOn(BackgroundType.Down);
    }

    public void ChangeSpriteOn(BackgroundType type)
    {
        switch (type)
        {
            case BackgroundType.Default:
                _spriteRenderer.sprite = _default;
                break;
            case BackgroundType.Up:
                _spriteRenderer.sprite = _up;
                break;
            case BackgroundType.Down:
                _spriteRenderer.sprite = _down;
                break;
            default:
                Debug.Log($"type null");
                break;
        }
    }

}
