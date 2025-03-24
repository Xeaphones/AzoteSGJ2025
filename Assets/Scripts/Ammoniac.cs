using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float offScreenOffset =0.5f;
    [SerializeField] float lifespan;
    [SerializeField] float conversionChance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject cleanParticle;
    [SerializeField] GameObject deathParticle;

    void Update()
    {
        if(transform.position.x < GameManager.instance.leftScreenAxis -offScreenOffset)
        {
            transform.position += new Vector3(GameManager.instance.screenWidth+2*offScreenOffset, 0);
        }
        else if(transform.position.x > GameManager.instance.rightScreenAxis +offScreenOffset)
        {
            transform.position += new Vector3(-GameManager.instance.screenWidth-2*offScreenOffset, 0);
        }

        if(transform.position.y < GameManager.instance.downScreenAxis -offScreenOffset)
        {
            transform.position += new Vector3(0, GameManager.instance.screenHeight +2*offScreenOffset);
        }
        else if(transform.position.y > GameManager.instance.topScreenAxis +offScreenOffset)
        {
            transform.position += new Vector3(0, -GameManager.instance.screenHeight-2*offScreenOffset);
        }   

        // end of life
        if (lifespan <= 0)
        {
            float percent = Random.Range(0f, 100f);
            if (percent <= conversionChance)
            {
                EndLife();
                Debug.Log("Ammoniac converted to fine matter");
            }
        }
        else
        {
            lifespan -= Time.deltaTime;
        }
    }

    public void OnCreation()
    {
        rb.linearVelocity = Random.insideUnitCircle.normalized*speed*Random.Range(0.3f ,1f);
        GameManager.instance.AddAmmoniac(1);
    }

    public void EndLife()
    {
        //Ajouter des particules fines
        GameObject newParticle = GameObject.Instantiate(deathParticle, rb.position, Quaternion.identity);
        newParticle.GetComponent<ParticleSystem>().Play();
        GameManager.instance.RemoveAmmoniac(1);
        GameManager.instance.AddToxicParticles(GameManager.instance.ammoniacToToxicParticleRate);
        Destroy(gameObject);
    }

    public void Delete()
    {
        GameObject newParticle = GameObject.Instantiate(cleanParticle, rb.position, Quaternion.identity);
        newParticle.GetComponent<ParticleSystem>().Play();
        GameManager.instance.RemoveAmmoniac(1);
        Destroy(gameObject);
    }
}