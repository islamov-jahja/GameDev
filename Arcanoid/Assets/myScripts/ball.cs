using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ball : MonoBehaviour {

    public AudioClip myClip;
    public AudioClip audioBax;
    // Use this for initialization
    int scores = 0;
    public Text live;
    public Text score;
    private const int COUNT_OF_LIVES = 3;
    private bool ballIsActive;
    private Vector3 ballVelocity;
    private Vector3 ballPosition;
    public Rigidbody rb;
    public GameObject ship;
    int countOfLives;
    int bricks;
    int bricksSt;

    void Start () {
        bricksSt = GameObject.FindGameObjectsWithTag("plane").Length;
        countOfLives = COUNT_OF_LIVES;
        ballVelocity = new Vector3(0f, 100f, 0f);
        ballIsActive = false;
        ballPosition = rb.transform.position;
    }

    // Update is called once per frame
    void Update() {
        bricks = GameObject.FindGameObjectsWithTag("plane").Length;
        scores = (bricks - bricksSt) * -10 - 10;
        score.text = "score: " + scores;
        live.text = "your lives: " + countOfLives; 

        if (Input.GetButtonDown("Jump") == true)
        {
            if (!ballIsActive)
            {
                rb.velocity = ballVelocity;
                ballIsActive = !ballIsActive;
            }
        }

        if (!ballIsActive)
        {
            // задаем новую позицию шарика
            ballPosition.x = ship.transform.position.x - 175;
            ballPosition.y = ship.transform.position.y + 80;

            // устанавливаем позицию шара
            transform.position = ballPosition;
        }

        if (transform.position.y <= 520)
        {
            ballIsActive = false;
            ballPosition = rb.transform.position;
            countOfLives--;
        }

        if (countOfLives == 0 || GameObject.FindGameObjectWithTag("plane") == null)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("score", scores);
            SceneManager.LoadScene(3);
        }

    }
    private Vector3 velocityUpX = new Vector3(20f, 100f, 0f);
    private Vector3 velocityDownX = new Vector3(-20f, 100f, 0f);
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Capsule")
        {
            gameObject.GetComponent<AudioSource>().clip = audioBax;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.name == "Mesh13")
        {
            gameObject.GetComponent<AudioSource>().clip = myClip;
            gameObject.GetComponent<AudioSource>().Play();
            if ((ship.transform.position.x - transform.position.x) < 169f)
                rb.velocity = velocityUpX;
            else if ((ship.transform.position.x - transform.position.x) > 179f)
                rb.velocity = velocityDownX;
            else
                rb.velocity = ballVelocity;
        }
    }
}
