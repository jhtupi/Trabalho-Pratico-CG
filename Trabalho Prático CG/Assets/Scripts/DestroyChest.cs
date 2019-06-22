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

        flag = Random.Range(50, 100); // Determina qual se o player ganhará vida ou escudo
        if (flag >= 50)
        {
            if (vidaPlayer.value < 100)
           {
                vidaPlayer.value = 100;
           }
            else
            {

                player = GameObject.Find("Player");
                player.gameObject.transform.GetChild(1).gameObject.SetActive(true); 
                


            }
        }
        
    }
}
