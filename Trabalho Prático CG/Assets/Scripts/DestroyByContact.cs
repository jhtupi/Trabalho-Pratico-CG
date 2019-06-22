﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject self, player;
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


        if (other.tag == "Player" || other.tag == "Shield")
        {
            player = GameObject.Find("Player");

            if (player.gameObject.transform.GetChild(1).gameObject.active)//Se o escudo estiver ativo
            {
                Destroy(self);
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }
                gameController.AddScore(scoreValue);
                player.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                return;
            }
            else
            {

                if (vida.value > 0)
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
            }


        } else if (other.tag != "Chest")
        {
            if (other.tag == "Boundary" || other.tag == "Enemy"|| other.tag == "Boss")
            {
                return;
            }

          
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            
            Destroy(other.gameObject);
            gameController.AddScore(scoreValue);
            Destroy(self);
            
         

        }

 
        
    }
}
