using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Tilemaps;
using UnityEditor;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] public int cost;
    [SerializeField] public bool isPolluted;
    [SerializeField] public bool isFlamable;
    [SerializeField] public Tile tile;
    [SerializeField] public bool isEffect;

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
