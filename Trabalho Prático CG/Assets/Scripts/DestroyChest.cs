using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyChest : MonoBehaviour
{
   
   
    public GameObject self;
    private Slider vidaPlayer;
    private GameController gameController;
    private float flag;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }


        if (other.tag == "Player")
        {
            Destroy(self);
        }
        

        if (GameObject.Find("CanvasVida"))
        {
            vidaPlayer = (Slider)FindObjectOfType(typeof(Slider));
        }

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        flag = Random.Range(50, 100); // Determina qual inimigo irá dar spawn
        if (flag >= 50)
        {
            if (vidaPlayer.value < 100)
           {
                vidaPlayer.value = 100;
           }
        }
        
    }
}
