using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Created by Yan Ho Chan - 301008722 - Oct 4, 2019 - COMP305 C094

public class GameController : MonoBehaviour {
    
    [Header("Wave Settings")]
    public GameObject hazard;   // Object to be spawned
    public Vector2 spawn;       // Hazards spawn point
    public int hazardCount;     // # of hazards per wave?
    public float startWait;     // Time until the first wave?
    public float spawnWait;     // Time betwen each hazard in each wave? 
    public float waveWait;      // Time between each waves?

    [Header("UI Settings")]
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private int score;
    private bool gameOver;
    private bool restart;

	//  Initialize
	void Start () {
        score = 0;
        StartCoroutine(SpawnWaves());
        gameOver = false;
        restart = false;
        UpdateScore();
	}
	
    void Update()
    {
        // Check if restarting
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {                             
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // Function for spawning waves of hazards
    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); 
        while(true)
        {
            // Spawning hazards
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawn.x, Random.Range(-spawn.y, spawn.y));
                //                                    11                     -4         4
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            // Restart logic
            if(gameOver)
            {
                //Restart text
                restartText.enabled = true;
                
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

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // When my game is over
        gameOver = true;

        gameOverText.enabled = true;
    }
}
