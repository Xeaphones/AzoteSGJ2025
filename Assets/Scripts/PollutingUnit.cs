using UnityEngine;
using UnityEngine.InputSystem.Controls;

public abstract class PollutingUnit : Unit
{
    public int pollutionGeneration;
    public float pollutionMultiplier;
    public int ticsBeforePollution;
    protected float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= ticsBeforePollution) 
        {
            timer = 0;
            // A RAJOUTER : 
            // créée une instance d'ammoniac
        }
        else 
        {
            timer += pollutionMultiplier * Time.deltaTime ;
        }

    }
}
