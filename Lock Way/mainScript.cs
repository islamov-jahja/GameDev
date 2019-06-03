using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using System;

public class mainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] statusOfDoors;
    private GameManager gameManager = GameManager.GetInstance();
    private int state;
    private int allCountOfDoors;
    public Text statistic;
    public Text timer;
    public int winState;
    private int _seconds = 0;
    private int _minutes = 0;

    void Start()
    {
        allCountOfDoors = GameObject.FindGameObjectsWithTag("Player").Length;
        state = -1;
        gameManager.state = 0;
        ChangeColorOfDoors();
        StartCoroutine("DoCheck");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");

        if (state != gameManager.state)
        {
            state = gameManager.state;
            ChangeColorOfDoors();
        }

        if (IsWin())
        {
            Debug.Log("Молодец, победил!!!");
        }
    }


    private void ChangeColorOfDoors()
    {
        int stat = 0;

        GameObject[] doors = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject door in doors)
        {
            if (door.GetComponent<door2>().countOfLives == 0)
            {
                door.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                stat++;
            }

            if (door.GetComponent<door2>().countOfLives != 0 && (door.GetComponent<door2>().codeZoneA == state || door.GetComponent<door2>().codeZoneB == state))
            {
                door.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
            }

            if (door.GetComponent<door2>().countOfLives != 0 && (door.GetComponent<door2>().codeZoneA != state && door.GetComponent<door2>().codeZoneB != state))
            {
                door.GetComponent<SpriteRenderer>().color = new Color(255, 215, 47);
            }
        }

        foreach (GameObject status in statusOfDoors)
        {
            if (state != -2)
            {
                if (status.GetComponent<statusOfDoor>().countOfTeleport != 0 && status.GetComponent<statusOfDoor>().state == state)
                {
                    status.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
                }

                if (status.GetComponent<statusOfDoor>().state != state || status.GetComponent<statusOfDoor>().countOfTeleport == 0)
                {
                    status.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
                }

                if (status.GetComponent<statusOfDoor>().isFinish)
                {
                    status.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                }
            }
        }

        statistic.text = "count of passed doors: " + stat + "/" + allCountOfDoors;
    }

    private bool IsWin()
    {
        int tempCount = 0;
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject door in doors)
        {
            if (door.GetComponent<door2>().countOfLives == 0)
            {
                tempCount++;
            }
        }

        if (tempCount == allCountOfDoors && state == winState)
        {
            return true;
        }

        return false;
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            //что-то сделать каждые  time секунд
            _seconds++;
            if (Convert.ToDouble(_seconds / 6) == 10f && _seconds != 0)
            {
                _minutes++;
                _seconds = 0;
                timer.text = _minutes.ToString() + ":" + _seconds.ToString();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
