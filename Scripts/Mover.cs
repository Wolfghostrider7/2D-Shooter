using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created by Yan Ho Chan - 301008722 - Oct 4, 2019 - COMP305 C094
public class Mover : MonoBehaviour {

    // Variable Declarations
    public float speed;

    private Rigidbody2D rBody;

	// Initialize
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;
	}
}
