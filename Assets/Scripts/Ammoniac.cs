using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float offScreenOffset =0.5f;
    [SerializeField] float lifespan;
    [SerializeField] Rigidbody2D rb;

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
    }

    public void OnCreation()
    {
        rb.linearVelocity = Random.insideUnitCircle.normalized*speed;
        GameManager.instance.AddAmmoniac(1);
    }

    public void EndLife()
    {
        //Ajouter des particules fines
        GameManager.instance.RemoveAmmoniac(1);
        GameManager.instance.AddToxicParticles(GameManager.instance.ammoniacToToxicParticleRate);
        Destroy(gameObject);
    }

    public void Delete()
    {
        GameManager.instance.RemoveAmmoniac(1);
        Destroy(gameObject);
    }
}