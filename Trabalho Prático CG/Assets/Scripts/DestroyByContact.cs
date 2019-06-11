using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject self;
    public int scoreValue;
    public GameController gameController;
    public Slider vida;



    void OnTriggerEnter(Collider other)
    {

        

        if (other.tag == "Player")
        {
            if(vida.value > 0)
            {
                vida.value -= 20;
                return;
            }
            else
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                gameController.GameOver();
            }
            
        } else if (other.tag != "chest")
        {
            if (other.tag == "Boundary")
            {
                return;
            }

            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            Destroy(other.gameObject);
            Destroy(self);

        }


        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(self);
        
    }
}
