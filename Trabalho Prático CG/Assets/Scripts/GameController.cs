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
    public int chestCount;
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

    private bool gameOver;
    private bool gameVictory;
    private bool restart;
    private bool continua;
    private int score;

    private void Start()
    {
        
        //StartCoroutine(SpawnChest());
        //StartCoroutine(SpawnWaves());



        gameOver = false;
        restart = false;
        gameVictory = false;
        continua = false;
        restartText.text = "";
        gameOverText.text = "";
        gameVictoryText.text = "";
        restartVitText.text = "";
        score = 0;
        UpdateScore();

    }

    public void Boss()
    {
        StopCoroutine(SpawnChest());
        StopCoroutine(SpawnWaves());
    }



    private void Update()
    {
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //mudar para fase seguinte
            }
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
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesX, spawnValuesX), self.transform.position.y, self.transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;

                

                if (flagEnemy >= 50) // Inimigo 1
                {
                    Instantiate(enemy1, spawnPosition, spawnRotation);
                }
                else // Inimigo 2
                {
                    // Instantiate(enemy2, spawnPosition, spawnRotation); 
                }
                
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Pressione 'R' para reiniciar";
                restart = true;
                break;
            }
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
    }

    public void GameVictory()
    {
        gameVictoryText.text = "Vitória!";
        gameVictory = true;
    }

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

}
