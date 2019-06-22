using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public int bossLife;
    public int scoreHit, scoreKill;
    private GameController gameController;
    public GameObject self, bombExplosion;
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
    public int qualBoss;

    



    private void Start()
    {

        if (GameObject.Find("CanvasVida"))
        {
            vidaPlayer = (Slider)FindObjectOfType(typeof(Slider));
        }

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        anim = GetComponent<Animator>();
        if (qualBoss == 1 || qualBoss == 2)
        {
            StartCoroutine(Evade());
        }
        else
        {
            StartCoroutine(Evade2());
        }
        

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

    // Evasão que contém vertical também
    IEnumerator Evade2()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            flagEvasao = Random.Range(0, 100);
            if (flagEvasao >= 50) // Evasão horizontal
            {
                targetManeuver = Random.Range(0, dodge) * -Mathf.Sign(transform.position.x);
            }
            else // Evasão vertical
            {
                targetManeuver = Random.Range(0, dodge) * -Mathf.Sign(transform.position.y);
            }

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
        if(qualBoss == 1 || qualBoss == 2)
        {
            float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, 0.0f);
            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
                GetComponent<Rigidbody>().position.y,
                GetComponent<Rigidbody>().position.z
            );
        } else
        {
            if (flagEvasao >= 50) // Evasão horizontal
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
            else // Evasão vertical
            {
                float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.y, targetManeuver, smoothing * Time.deltaTime);
                GetComponent<Rigidbody>().velocity = new Vector3(0.0f, newManeuver, 0.0f);
                GetComponent<Rigidbody>().position = new Vector3
                (
                    
                    GetComponent<Rigidbody>().position.x,
                    Mathf.Clamp(GetComponent<Rigidbody>().position.y, 1, 10),
                    GetComponent<Rigidbody>().position.z
                );
            }

        }

        
       
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "PlayerShot" || other.tag == "Bomb")
        {
            if (bossLife > 0)
            {
                if(other.tag == "Bomb")
                {
                    bossLife -= 20;
                    Instantiate(bombExplosion, other.transform.position, other.transform.rotation);
                } else
                {
                    bossLife -= 10;
                }
                
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
          Destroy(other.gameObject); //??????????????????????????
            
        }
    }
}
