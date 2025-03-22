using Unity.VisualScripting;
using UnityEngine;

public class Fire : PollutingUnit
{
    [SerializeField] public float duration;
    private Unit unit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnCreation(Unit previousUnit)
    {
        unit = previousUnit;
    }

    void Start()
    {
        
    }

    protected new void Update()
    {
        base.Update();
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            duration -= Time.deltaTime;
        }
    }
}
