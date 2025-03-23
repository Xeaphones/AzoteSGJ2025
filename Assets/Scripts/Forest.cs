using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Forest : CleaningUnit
{
    [SerializeField] public bool onFire = false;
    [SerializeField] public float maxHp;
    [SerializeField] public float currentHp = 0;
    [SerializeField] public GameObject firePrefab;
    [SerializeField] public new Collider2D collider;
    [SerializeField] public Tilemap effectTilemap;
    private bool hasFireOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
        effectTilemap = GameObject.Find("Effect").GetComponent<Tilemap>();
    }

    new void Update()
    {
        base.Update();
        if (currentHp <= 0)
        {
            Destroy(gameObject);
            tilemap.SetTile(tilemap.WorldToCell(transform.position), defaultTile);
        }
        else if (currentHp <= maxHp - 3 & !hasFireOn)
        {
            hasFireOn = true;
            collider.enabled = false;
            GameObject newFire = Instantiate (firePrefab, transform.position, transform.rotation);
            effectTilemap.SetTile(effectTilemap.WorldToCell(transform.position), firePrefab.GetComponent<Unit>().tile);
            newFire.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            newFire.GetComponent<Unit>().tilemap = effectTilemap;
        }

        // when onFire, loose hp
        if (onFire)
        {
            currentHp -= Time.deltaTime;
            Debug.Log("forest is loosing hp due to fire ");
        }
        
    }

    public void Extinguish()
    {
        currentHp = maxHp;
        hasFireOn = false;
        onFire = false;
    }

    new void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);

        GameObject other = collision.gameObject;

        if (other.GetComponent<Fire>() & onFire == false)
        {
            onFire = true;
            if (other.transform.position == transform.position)
            {
                hasFireOn = true;
                collider.enabled = false;
            }
        }
        else if (other.GetComponent<RainCondensator>() & onFire == true)
        {
            onFire = false;
            collider.enabled = true;
            hasFireOn = false;
            currentHp = maxHp;
        }

        // // if the forest is on fire for too long : create a fire at position
        // if (other.GetComponent<Fire>() & other.transform.position != transform.position & currentHp <= maxHp - 2)
        // {
        //     GameObject newFire = Instantiate (firePrefab, transform.position, transform.rotation);
        // }
    }
}
