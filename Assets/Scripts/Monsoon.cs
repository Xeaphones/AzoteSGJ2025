using System;
using UnityEngine;

public class Monsoon : CleaningUnit
{
    void Start()
    {
        GameManager.instance.sound.PlayMonsoonSound();
        GameManager manager = FindFirstObjectByType<GameManager>();
        Debug.Log("Monsoon created.");
        manager.CleanAllAmmoniac();
        manager.CleanAllFire();
        manager.ExtinctAllForest();
    }

    new void Update()
    {
        Destroy(gameObject);
    }

}