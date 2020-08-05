using UnityEngine;

public class Platforms : MonoBehaviour
{
    public void Hit()
    {
        gameObject.SetActive(false);
        GameController.instance.PlatformHide();
    }

    void Update()
    {
        if (GameController.instance.GameIsStarted())
        {
            float speed = GameController.instance.GetMoveSpeed();
            Vector3 newPosition = transform.position;
            newPosition.x -= speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
