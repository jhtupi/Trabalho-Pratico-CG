using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public int bossLife;
    public int scoreHit, scoreKill;
    private GameController gameController;
    public GameObject self;
    public float tempoMorte;
    private Slider vidaPlayer;
    Animator anim;

    private void Start()
    {

        if (GameObject.Find("CanvasVida"))
        {
            vidaPlayer = (Slider)FindObjectOfType(typeof(Slider));
        }

        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        anim = GetComponent<Animator>();

    }

    // Animação da morte
    IEnumerator Die()
    {
        anim.SetTrigger(Animator.StringToHash("Died"));
        yield return new WaitForSeconds(tempoMorte);
        Destroy(self.gameObject);

    }

    private void Update()
    {
        
    }




    void OnTriggerEnter(Collider other)
    {

        if (bossLife > 0)
        {
            bossLife -= 10;
            gameController.AddScore(scoreHit);
            // Chama animação do Hit
            anim.SetTrigger(Animator.StringToHash("Hit"));
            if (bossLife <= 0)
            {
                gameController.AddScore(scoreKill);
                StartCoroutine(Die()); // Animação da morte
                                       // Chamar a função para encerrar a fase
            }
        }
        // Boss morreu
        
        Destroy(other.gameObject);
    }
}
