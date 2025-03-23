using UnityEngine;

[CreateAssetMenu(fileName = "AudioObject_SO", menuName = "Scriptable Objects/AudioObject_SO")]
public class AudioObject_SO : ScriptableObject
{
    public AudioClip Clip;
    public bool isLooping;
    public float volume = 0.5f;
}