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
    private GameController gameController;
    private Slider vida;


    private void Start()
    {

        if (GameObject.Find("CanvasVida"))
        {
            vida = (Slider)FindObjectOfType(typeof(Slider));
        }

        gameController = GameObject.Find("GameController").GetComponent<GameController>();

    }


    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            if(vida.value > 0)
            {
                vida.value -= 20;
                Destroy(self);
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }
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
            if (other.tag == "Boundary" || other.tag == "Enemy")
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
