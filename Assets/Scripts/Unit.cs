using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public abstract class Unit : MonoBehaviour
{
    public float cost;
    public bool isPolluted = false;
    public bool isFlamable = false;
    public bool isEmpty = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if is colliding with ammoniac : isPolluted = true
    }
}
