using UnityEngine;

public class Farm : PollutingUnit
{
    [SerializeField] public bool onFire = false;
    [SerializeField] public float maxHp;
    [SerializeField] public float currentHp = 0;
    [SerializeField] public GameObject firePrefab;
    private bool hasFireOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    new void Update()
    {
        base.Update();
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
        else if (currentHp <= maxHp - 2 & !hasFireOn)
        {
            hasFireOn = true;
            GameObject newFire = Instantiate (firePrefab, transform.position, transform.rotation);
        }

        // when onFire, loose hp
        if (onFire)
        {
            currentHp -= Time.deltaTime;
            Debug.Log("forest is loosing hp due to fire ");
        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

        if (other.GetComponent<Fire>() & onFire == false)
        {
            onFire = true;
            if (other.transform.position == transform.position)
            {
                hasFireOn = true;
            }
        }
        else if (other.GetComponent<RainCondensator>() & onFire == true)
        {
            onFire = false;
            hasFireOn = false;
            currentHp = maxHp;
        }
    }
}
