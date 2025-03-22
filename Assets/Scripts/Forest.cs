using UnityEngine;

public class Forest : CleaningUnit
{
    [SerializeField] public bool onFire = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    new void Update()
    {
        base.Update();
        // when onFire, replace the instance by forestOnFire object
        if (onFire)
        {
            Destroy(gameObject);
        }
        
    }
}
