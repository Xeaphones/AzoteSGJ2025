using UnityEngine;

public class RainCondensator : CleaningUnit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cost = 4;
        effectZone = 1;
        ticsBeforeCleaning = 20;
        cleaningPower = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
