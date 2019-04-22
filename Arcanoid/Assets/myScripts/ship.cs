using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour {

    // Use this for initialization
    public float shipVelocity;
    private Vector3 shipPosition;

    void Start () {
        shipPosition = gameObject.transform.position;
        shipVelocity = 2.5f;
    }
	
	// Update is called once per frame
	void Update () {
        shipPosition.x += Input.GetAxis("Horizontal") * shipVelocity;
        if (shipPosition.x > 971 && shipPosition.x < 1131)
            transform.position = shipPosition;
        else
            shipPosition = transform.position;
	}
}

