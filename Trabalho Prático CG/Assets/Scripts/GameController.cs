using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject Chest;
//  public GameObject enemy2;
    public GameObject self;
    public float spawnValuesX;
    public int enemyCount;
   // public int chestCount;
    public int flagChest;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private float flagEnemy;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text gameVictoryText;
    public Text restartVitText;
    public int pontuacaoBoss;

    public bool gameOver;
    public bool gameVictory;
    public bool restart;
    public bool continua;
    public int score, faseAtual;
    

    public Camera[] cameras;
    public int numeroCameras;
    public int NumeroMaximo;
    private GameObject player;


    private void Start()
    {
        
        
        StartCoroutine(SpawnWaves());
 
        gameOver = false;
        restart = false;
        gameVictory = false;
        continua = false;
        restartText.text = "";
        gameOverText.text = "";
        gameVictoryText.text = "";
        restartVitText.text = "";
        score = 0;
        player = GameObject.Find("Player");
        UpdateScore();

        NumeroMaximo = cameras.Length;
        numeroCameras = 1;
        foreach(Camera obj in cameras)
        {
            obj.gameObject.SetActive(false);
        }
        cameras[numeroCameras - 1].gameObject.SetActive(true);
    }

    public void Boss()
    {
       // player.GetComponent<PlayerScroller>().stop();
        StopCoroutine(SpawnWaves());
    }



    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (continua)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if(faseAtual == 1)
                {
                    SceneManager.LoadScene("Fase 2");
                } else if (faseAtual == 2)
                {
                    SceneManager.LoadScene("Fase 3");
                } 
                //mudar para fase seguinte

            }
        }

        if (gameOver)
        {
            restartText.text = "Pressione 'R' para reiniciar";
            restart = true;
            

        }

        if (gameVictory)
        {
            restartVitText.text = "Pressione 'P' para continuar";
            continua = true;
        }

        if(Input.GetKeyDown ("v") && numeroCameras < NumeroMaximo)
        {
            numeroCameras++;
            foreach(Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }
                cameras[numeroCameras - 1].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown("v") && numeroCameras == NumeroMaximo)
        {
            foreach (Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }
            cameras[numeroCameras - 1].gameObject.SetActive(true);
            numeroCameras = 0;
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                flagEnemy = Random.Range(50, 100); // Determina qual inimigo irá dar spawn
                Vector3 spawnPosition = new Vector3(Random.Range(-4,4), Random.Range(3, 6), self.transform.position.z);
                Quaternion spawnRotation = new Quaternion(self.transform.rotation.x, 180.0f, self.transform.rotation.z, self.transform.rotation.w);
                //Quaternion spawnRotation = Quaternion.identity;

                if (flagEnemy <= 95) // Inimigo 1
                {
                    Instantiate(enemy1, spawnPosition, spawnRotation);
                }
                else // Baú
                {
                    enemyCount = 1;
                    spawnPosition = new Vector3(0, 3, self.transform.position.z);
                    Instantiate(Chest, spawnPosition, spawnRotation);
                }
                
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);


        }

    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public int GetScore()
    {
        return score;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        GetComponent<AudioSource>().Play();
    }

    public void GameVictory()
    {
        gameVictoryText.text = "Vitória!";
        gameVictory = true;
    }

    /*
    IEnumerator SpawnChest()
    {
        yield return new WaitForSeconds(startWait);
        while (true)

        {

            for (int i = 0; i < chestCount; i++)
            {
                flagChest = Random.Range(0, 100); 
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesX, spawnValuesX), self.transform.position.y, self.transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                if (flagChest >= 50) 
                {
                    Instantiate(Chest, spawnPosition, spawnRotation);
                }

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }


    }
    */

}
