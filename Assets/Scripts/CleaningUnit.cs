using UnityEngine;
using UnityEngine.InputSystem.Controls;
using System.Collections.Generic;
using System.Linq;

public abstract class CleaningUnit : Unit
{
//     [SerializeField] public int effectZone;
//     [SerializeField] public int ticsBeforeCleaning;
//     [SerializeField] public int cleaningPower;
//     [SerializeField] private float timer;
//     [SerializeField] List <GameObject> currentCollisions = new List <GameObject> ();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

        if (collision.gameObject.GetComponent<Particle>())
        {
            Destroy(other);
            Debug.Log("Ammoniac destroy");
        }
    }
}
