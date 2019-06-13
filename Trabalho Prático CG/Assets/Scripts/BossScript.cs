using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    private int bossLife = 100;
    public int scoreHit, scoreKill;
    private GameController gameController;
    private Slider vidaPlayer;

    private void Start()
    {

        if (GameObject.Find("CanvasVida"))
        {
            vidaPlayer = (Slider)FindObjectOfType(typeof(Slider));
        }

        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

    }


    void OnTriggerEnter(Collider other)
    {

        if (bossLife > 0)
        {
            bossLife -= 50;
            gameController.AddScore(scoreHit);
        }
        // Boss morreu
        else
        {
            gameController.AddScore(scoreKill);
            // Chamar animação de morte
            // Chamar a função para encerrar a fase
        }
        Destroy(other.gameObject);

    }
}
