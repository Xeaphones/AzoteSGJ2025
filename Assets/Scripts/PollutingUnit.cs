using UnityEngine;
using UnityEngine.InputSystem.Controls;

public abstract class PollutingUnit : Unit
{
    [SerializeField] GameObject particlePrefab;
    [SerializeField] public int pollutionGeneration;
    [SerializeField] public float pollutionMultiplier;
    [SerializeField] public int ticsBeforePollution;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (timer >= ticsBeforePollution) 
        {
            timer = 0;
            for (int i = 0 ; i < pollutionGeneration ; i++)
            {
                CreateParticle();
            }
        }
        else 
        {
            timer += pollutionMultiplier * Time.deltaTime ;
        }
    }

    void CreateParticle()
    {
        GameObject newParcticle = Instantiate (particlePrefab, transform.position, transform.rotation);
        Particle particleScript = newParcticle.GetComponent<Particle>();
        particleScript.OnCreation();
    }
}
