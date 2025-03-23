using Unity.VisualScripting;
using UnityEngine;

public class Fire : PollutingUnit
{
    [SerializeField] public float duration = 10;
    private Unit source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    new void Update()
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

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

        if (other.GetComponent<RainCondensator>() & collision.enabled)
        {
            Destroy(gameObject);
            Debug.Log("Fire has been extinguished");
        }
    }
}
