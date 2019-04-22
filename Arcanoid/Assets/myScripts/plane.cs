using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class plane : MonoBehaviour {

    public GameObject effect;
    GameObject effectFordestroy;
    public Rigidbody ball;
    public GameObject planeS;
    private Vector3 velocityOfBall = new Vector3(-20f, -100f, 0f);
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ball")
        {
            effectFordestroy = Instantiate(effect, planeS.transform.position, planeS.transform.rotation) as GameObject;
            ball.velocity = velocityOfBall;
            Destroy(planeS);
        }
    }
}
