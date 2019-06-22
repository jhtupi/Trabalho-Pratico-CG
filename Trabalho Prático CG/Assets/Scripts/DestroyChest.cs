using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyChest : MonoBehaviour
{
    public GameObject player;

    public GameObject self, shield;
    private Slider vidaPlayer;
    private GameController gameController;
    private float flag;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {  
               Destroy(self);
        }
        else
        {
            return;
        }
        

        if (GameObject.Find("CanvasVida"))
        {
            vidaPlayer = (Slider)FindObjectOfType(typeof(Slider));
        }

        //gameController = GameObject.Find("GameController").GetComponent<GameController>();

        flag = Random.Range(0, 150); // Determina qual se o player ganhará no baú

        // Aumenta a vida do player
        if (flag >= 0 && flag < 50)
        {
            vidaPlayer.value = 100;
        }
        // Ativa o escudo do player
        else if (flag >= 50 && flag < 100)
        {
            player.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }

        // Dá a possibilidade de usar a bomba
        else if (flag >= 100 && flag <= 150)
        {
            player.GetComponent<PlayerController>().IncreaseBomb();
        }
        
    }
}
