using System;
using UnityEngine;

public class Monsoon : CleaningUnit
{
    void Start()
    {
        GameManager manager = FindFirstObjectByType<GameManager>();
        manager.CleanAllAmmoniac();
        manager.CleanAllFire();
        manager.ExtinctAllForest();
        Destroy(gameObject);
    }
}