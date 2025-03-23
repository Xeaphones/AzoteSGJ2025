using System;
using UnityEngine;

public class Monsoon : CleaningUnit
{
    void Start()
    {
        GameManager.instance.sound.PlayMonsoonSound();
        Debug.Log("Monsoon created.");
        GameManager.instance.CleanAllAmmoniac();
        GameManager.instance.CleanAllFire();
        GameManager.instance.ExtinctAllForest();
    }

    new void Update()
    {
        Destroy(gameObject);
    }

}