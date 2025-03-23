using UnityEngine;

public class AudioObject : MonoBehaviour
{
    private AudioObject_SO _soundSO;
    [SerializeField] private AudioSource _audioSource;
    

    private void Update() 
    {
        if (!_soundSO.isLooping && !_audioSource.isPlaying) {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioObject_SO so)
    {
        _soundSO = so;
        _audioSource.clip = _soundSO.Clip;
        _audioSource.loop = _soundSO.isLooping;
        _audioSource.volume = _soundSO.volume;
        _audioSource.Play();
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }

    public void PlayAgain()
    {
        _audioSource.Play();
    }
}
