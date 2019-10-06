using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created by Yan Ho Chan - 301008722 - Oct 4, 2019 - COMP305 C094
[System.Serializable]
public class Boundary
{
    //Properties  Variables 
    public float xMin, xMax, yMin, yMax;
    
}

public class PlayerController : MonoBehaviour
{

    //Variable Declaration
    [Header("Movement Settings")]
    public float speed = 5.0f;
    //public float xMin, xMax, yMin, yMax;
    public Boundary boundary;

    [Header("Attack Settings")]
    public GameObject laser;
    public GameObject laserSpawn;
    public float fireRate = 0.5f;

    private Rigidbody2D rBody;
    private float myTime = 0.0f;

    
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        myTime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && myTime > fireRate)
        {
            Instantiate(laser, laserSpawn.transform.position, laserSpawn.transform.rotation);
            myTime = 0.0f;
        }
    }

    //Used for physics
    void FixedUpdate()
    {
        //Read input
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
       
        Vector2 movement = new Vector2(horiz, vert);

        //Move the player
        
        rBody.velocity = movement * speed;

        //Restricts player from leaving play area
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),  // Restrict x position to xMin and xMax
            Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax)); // Restrict y position to yMin and yMax
    }
}
