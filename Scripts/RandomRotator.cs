using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created by Yan Ho Chan - 301008722 - Oct 4, 2019 - COMP305 C094
public class RandomRotator : MonoBehaviour {

    public float tumble;

    private Rigidbody2D rBody;

	// Initialize
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rBody.angularVelocity = Random.value * tumble;
	}
}
