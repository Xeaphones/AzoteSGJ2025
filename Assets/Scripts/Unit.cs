using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] public float cost;
    [SerializeField] public bool isPolluted;
    [SerializeField] public bool isFlamable;
    [SerializeField] public bool isEmpty = true;


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
