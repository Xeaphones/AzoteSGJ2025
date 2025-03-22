using UnityEngine;

public class Funnel : CleaningUnit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cost = 2;
        effectZone = 2;
        ticsBeforeCleaning = 10;
        cleaningPower = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
