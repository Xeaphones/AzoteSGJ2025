using UnityEngine;

public class RainCondensator : CleaningUnit
{
    [SerializeField] public bool isActive;
    [SerializeField] private float timer;
    [SerializeField] public int activationTics;

    [SerializeField] new public Collider2D collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (timer >= activationTics)
        {
            collider.enabled = !collider.enabled;
            timer = 0;
            Debug.Log(collider.enabled);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
