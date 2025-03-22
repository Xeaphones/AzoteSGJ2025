using UnityEngine;

public class Forest : CleaningUnit
{
    public int pollutionGeneration = 1;
    public int hp = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cost = 2;
        isFlamable = true;
        effectZone = 2;
        ticsBeforeCleaning = 10;
        cleaningPower = 1;
        timer = 0;
    }

    void Update()
    {
        // Si saison == hiver : change le multiplier ect ect
        // Si en feu : génère des particules d'ammoniaque, perd des pvs
        // si pv == 0 : détruit la foret
    }
}
