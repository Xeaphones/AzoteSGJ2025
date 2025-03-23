using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire : PollutingUnit
{
    [SerializeField] public float duration = 10;
    private Unit source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.sound.PlayFireSound();
    }

    new void Update()
    {
        base.Update();
        if (duration <= 0)
        {
            Destroy(source);
            Destroy(gameObject);
            tilemap.SetTile(tilemap.WorldToCell(transform.position), defaultTile);
            Debug.Log("Fire deleted");
        }
        else
        {
            duration -= Time.deltaTime;
        }
    }

    void OnDestroy()
    {
        tilemap.SetTile(tilemap.WorldToCell(transform.position), defaultTile);
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
