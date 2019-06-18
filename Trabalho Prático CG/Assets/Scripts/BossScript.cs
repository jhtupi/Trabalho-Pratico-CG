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


    // Variáveis para evasão

    public float xMin, xMax;
    public float dodge;
    public float smoothing;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    
    private float targetManeuver;
    private float flagEvasao;

    

    private void Start()
    {

        if (GameObject.Find("CanvasVida"))
        {
            vidaPlayer = (Slider)FindObjectOfType(typeof(Slider));
        }

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        anim = GetComponent<Animator>();
        StartCoroutine(Evade());

    }

    // Script para evasão
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(0, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    // Animação da morte
    IEnumerator Die()
    {
        anim.SetTrigger(Animator.StringToHash("Died"));
        yield return new WaitForSeconds(tempoMorte);
        Destroy(self.gameObject);
        gameController.GameVictory();
        // Chamar vitória da fase
    }


    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, 0.0f);
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
            GetComponent<Rigidbody>().position.y,
            GetComponent<Rigidbody>().position.z
        );
       
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "PlayerShot")
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
}
