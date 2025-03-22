using UnityEngine;

public class Farm : PollutingUnit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cost = 2;
        pollutionGeneration = 1;
        pollutionMultiplier = 1.5f;
        ticsBeforePollution = 5;
        timer = 0;
    }

    void Update()
    {
        // Si saison == hiver : change le multiplier ect ect
    }
}
