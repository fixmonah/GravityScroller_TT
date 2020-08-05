using UnityEngine;

public class Ball : MonoBehaviour
{
    public void StartGame()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    public void EndGame()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        BallDestroyer ballDestroyer = other.gameObject.GetComponent<BallDestroyer>();
        if (ballDestroyer != null)
        {
            GameController.instance.EndGame();
        }

        PlatformHit platformHit = other.gameObject.GetComponent<PlatformHit>();
        if (platformHit != null)
        {
            GameController.instance.GetAudioController().Play(AudioControllerTrack.BallBump);
        }
    }
}
