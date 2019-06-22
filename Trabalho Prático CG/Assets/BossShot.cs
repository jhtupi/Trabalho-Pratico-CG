using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BossShot : MonoBehaviour
{
    public float shotSpeed;
    public int shotDamage;
    public GameObject playerExplosion, self, player;

    private GameController gameController;
    private Slider vida;

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
    }
    void Start()
    {
        if (GameObject.Find("CanvasVida"))
        {
            vida = (Slider)FindObjectOfType(typeof(Slider));
        }

        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        player = GameObject.Find("Player");
        GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player" || other.tag == "Shield")
        {
            if (other.tag == "Shield")
            {
                player.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            
            else
            {
                if (vida.value > 0)
                {
                    vida.value -= shotDamage;
                    Destroy(self);
                    return;
                }
                else
                {
                    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject);
                    gameController.GameOver();
                }
            }
            Destroy(self);
        }
        

    }
}

