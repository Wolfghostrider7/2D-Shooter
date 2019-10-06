using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created by Yan Ho Chan - 301008722 - Oct 4, 2019 - COMP305 C094

public class DestroyByContact : MonoBehaviour {

    public GameObject explosionAsteroid;
    public GameObject explosionPlayer;
    public int scoreValue = 10;

    private GameController gameControllerScript;

	// Initialize
	void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if(gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerScript == null)
        {
            Debug.Log("Cannot find GameController script on GameController object");
        }
	}

    // Triggers when collison occurs
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            // Trigger Game Over 
            gameControllerScript.GameOver();
        }
        
        Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);
        gameControllerScript.AddScore(scoreValue);
        
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
