using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _gravityUp;
    [SerializeField] private AudioClip _gravityDown;
    [SerializeField] private AudioClip _startGame;
    [SerializeField] private AudioClip _endGame;
    [SerializeField] private AudioClip _ballBump;
    [Space]
    [SerializeField] private AudioSource _audioSource;

    public void SoundMute(bool mute)
    {
        _audioSource.mute = mute;
    }

    public void Play(AudioControllerTrack track)
    {
        switch (track)
        {
            case AudioControllerTrack.GravityUp:
                _audioSource.clip = _gravityUp;
                break;
            case AudioControllerTrack.GravityDown:
                _audioSource.clip = _gravityDown;
                break;
            case AudioControllerTrack.StartGame:
                _audioSource.clip = _startGame;
                break;
            case AudioControllerTrack.EndGame:
                _audioSource.clip = _endGame;
                break;
            case AudioControllerTrack.BallBump:
                _audioSource.clip = _ballBump;
                break;
            default:
                Debug.Log($"audio clip do nof find");
                break;
        }
        _audioSource.Stop();
        _audioSource.Play();
    }
}
