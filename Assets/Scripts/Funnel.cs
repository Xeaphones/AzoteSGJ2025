using UnityEngine;

public class Funnel : CleaningUnit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.sound.PlayFunnelSound();
    }
}
