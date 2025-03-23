using UnityEngine;

public class Livestock : PollutingUnit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.sound.PlayLivestockSound();
    }
}
