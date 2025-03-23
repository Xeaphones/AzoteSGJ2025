susing System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] PlayerController goodPlayer;
    [SerializeField] PlayerController badPlayer;
    [field: SerializeField] public SoundManager sound{get; private set;}
    [SerializeField] int totalAmmoniac;
    [SerializeField] int totalToxicParticles;
    [SerializeField] int maxAmmoniac;
    [SerializeField] int maxToxicParticles;
    [field: SerializeField] public int ammoniacToToxicParticleRate{get; private set;}
    


    [field: SerializeField] public float topScreenAxis{get; private set;}
    [field: SerializeField] public float downScreenAxis{get; private set;}
    [field: SerializeField] public float rightScreenAxis{get; private set;}
    [field: SerializeField] public float leftScreenAxis{get; private set;}

    public int totalAmmoniac;
    public int totalToxicParticles;
    public float screenHeight;
    public float screenWidth;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("ERROR : More than one instance of GameManager");
        } 

        instance = this;
    }

    void Start()
    {
        screenHeight = topScreenAxis - downScreenAxis;
        screenWidth = rightScreenAxis - leftScreenAxis;
    }


    public void AddAmmoniac(int value)
    {
        totalAmmoniac += value;
        //Update display
    }

    public void AddToxicParticles(int value)
    {
        totalToxicParticles += value;
        //Update display
    }

    public void RemoveAmmoniac(int value)
    {
        totalAmmoniac -= value;
        //Update display
    }

    // C la mousson lekipe
    public void CleanAllAmmoniac()
    {
        Particle[] particles = FindObjectsByType<Particle>(FindObjectsSortMode.None);
        foreach (Particle obj in particles)
        {
            Destroy(obj.gameObject);
        }

        totalAmmoniac = 0;
        
    }

    public void CleanAllFire()
    {
        Fire[] particles = FindObjectsByType<Fire>(FindObjectsSortMode.None);
        foreach (Fire obj in particles)
        {
            Destroy(obj.gameObject);
        }
    }

    public void ExtinctAllForest()
    {
        Forest[] particles = FindObjectsByType<Forest>(FindObjectsSortMode.None);
        foreach (Forest obj in particles)
        {
            obj.Extinguish();
        }
    }
}