using System.Collections.Generic;
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
    [SerializeField] int currentActionPointsPolueur = 6;
    [SerializeField] int currentActionPointsCleaner = 7;
    [SerializeField] string currentControllerCleaner = "A";
    [SerializeField] string currentControllerPolueur= "V";
    [SerializeField] string currentTerrainPolueur = "Foret";
    [SerializeField] string currentTerrainCleaner = "Foret";
    
    
    [field: SerializeField] public int ammoniacToToxicParticleRate{get; private set;}
    


    [field: SerializeField] public float topScreenAxis{get; private set;}
    [field: SerializeField] public float downScreenAxis{get; private set;}
    [field: SerializeField] public float rightScreenAxis{get; private set;}
    [field: SerializeField] public float leftScreenAxis{get; private set;}

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
            Destroy(obj);
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
    
    public int GetCurrentActionPointsPolueur()
    {
        return currentActionPointsPolueur;
    }
    
    public int GetCurrentActionPointsCleaner()
    {
        return currentActionPointsCleaner;
    }
    
    public string GetCurrentControllerPolueur()
    {
        return currentControllerPolueur;
    }
    
    public string GetCurrentControllerCleaner()
    {
        return currentControllerCleaner;
    }
    
    public string GetCurrentTerrainPolueur()
    {
        return currentTerrainPolueur;
    }
    
    public string GetCurrentTerrainCleaner()
    {
        return currentTerrainCleaner;
    }
}