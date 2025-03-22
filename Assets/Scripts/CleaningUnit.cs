using UnityEngine;
using UnityEngine.InputSystem.Controls;

public abstract class CleaningUnit : Unit
{
    public int effectZone;
    public int ticsBeforeCleaning;
    public int cleaningPower;
    protected float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= ticsBeforeCleaning) 
        {
            timer = 0;
            // A RAJOUTER : 
            // si il y a de l'ammoniac dans la range effectZone :
            // delete autant que cleaningPower
        }
        else 
        {
            timer += Time.deltaTime ;
        }

    }
}
