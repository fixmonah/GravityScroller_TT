using UnityEngine;

public class PlatformHit : MonoBehaviour
{
    [SerializeField] private Platforms _platforms;
    void Start()
    {
        _platforms = transform.parent.GetComponent<Platforms>();
    }

    private void OnCollisionEnter(Collision other)
    {
        PlatformDestroyer hit = other.collider.gameObject.GetComponent<PlatformDestroyer>();
        if (hit != null)
        {
            _platforms.Hit();
        }
    }
}
