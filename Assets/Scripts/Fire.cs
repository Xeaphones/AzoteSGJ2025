using Unity.VisualScripting;
using UnityEngine;

public class Fire : PollutingUnit
{
    [SerializeField] public float duration = 20;
    private Unit source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnCreation(Unit unit)
    {
        source = unit;
    }

    void Start()
    {
        
    }

    protected new void Update()
    {
        base.Update();
        if (duration <= 0)
        {
            Destroy(source);
            Destroy(gameObject);
            Debug.Log("Fire deleted");
        }
        else
        {
            duration -= Time.deltaTime;
        }
    }
}
