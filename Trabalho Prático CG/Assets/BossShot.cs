using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BossShot : MonoBehaviour
{
    public float shotSpeed;
    public int shotDamage;
    public GameObject playerExplosion, self;

    private GameController gameController;
    private Slider vida;

    void Start()
    {
        if (GameObject.Find("CanvasVida"))
        {
            vida = (Slider)FindObjectOfType(typeof(Slider));
        }

        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

        GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
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

