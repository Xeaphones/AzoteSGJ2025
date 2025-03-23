using UnityEngine;

public class RainCondensator : CleaningUnit
{
    [SerializeField] public bool isActive;
    [SerializeField] private float timer;
    //[SerializeField] public int activationTics;
    [SerializeField] private float firstRainStartDelay;
    [SerializeField] private float rainDuration;
    [SerializeField] private float rainCooldown;

    [SerializeField] new public Collider2D collider;
    [SerializeField] GameObject clouds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isActive = false;
        timer = rainCooldown - firstRainStartDelay;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if(isActive)
        {
            if(timer > rainDuration) 
            {
                timer = 0;
                StopRain();
            }
        }
        else
        {
            if(timer > rainCooldown) 
            {
                timer = 0;
                ActivateRain();
            }
        }



        // if (timer >= activationTics)
        // {
        //     collider.enabled = !collider.enabled;
        //     timer = 0;
        //     Debug.Log(collider.enabled);
        // }
        // else
        // {
        //     timer += Time.deltaTime;
        // }
    }

    void ActivateRain()
    {
        GameManager.instance.sound.PlayRainSound();
        isActive = true;
        clouds.SetActive(true);
        collider.enabled = true;
    }

    void StopRain()
    {
        isActive = false;
        clouds.SetActive(false);
        collider.enabled = false;
    }
}
