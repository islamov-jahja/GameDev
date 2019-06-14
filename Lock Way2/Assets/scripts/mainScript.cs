using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.scripts;
using TMPro;
using UnityEngine.SceneManagement;

public class mainScript : MonoBehaviour
{
    public TextMeshProUGUI winOrLose;
    public int level = 1;
    public GameObject[] statusOfDoors;
    private GameManager gameManager = GameManager.GetInstance();
    private int state;
    private int allCountOfDoors;
    public TextMeshProUGUI statistic;
    public TextMeshProUGUI timer;
    public int winState;
    private int _seconds = 0;
    private int _minutes = 0;
    public bool _withFirstKey;
    public Vector3 _positionToInsert;
    public float delta = 0.23f;
    public List<Key> keys;
    public GameObject man;

    void Start()
    {
        allCountOfDoors = GameObject.FindGameObjectsWithTag("Player").Length;
        state = -1;
        gameManager.state = 0;
        RemoveMan();
        ChangeColorOfDoors();
        if (!_withFirstKey)
        {
            _positionToInsert = new Vector3(0.09f, 4.1f, 0f);
        }else
        {
            _positionToInsert = new Vector3(0.38f, 4.1f, 0f);
        }

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
            RemoveMan();
        }

        if (IsWin())
        {
            gameManager.minutesResult = _minutes;
            gameManager.secondsResult = _seconds;
            gameManager.level = level;

            StopCoroutine("DoCheck");
            StartCoroutine("Win");
        }

        /*if (IsLosePosition())
        {
            Debug.Log("проиграл");
        }*/
    }

    IEnumerator Win()
    {
        winOrLose.text = "You win!";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }

    /*private bool IsLosePosition()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Player");

        int m_state = GameManager.GetInstance().state;

        foreach (GameObject door in doors)
        {
            if ((door.GetComponent<door2>().codeZoneA == m_state || door.GetComponent<door2>().codeZoneB == m_state) && door.GetComponent<door2>().countOfLives > 0 && state != -2)
            {
                foreach(GameObject status in statusOfDoors)
                {
                    if (state == status.GetComponent<statusOfDoor>().state && status.GetComponent<statusOfDoor>().countOfTeleport > 0)
                        return false;
                }
            }
        }

        return true;
    }*/

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
        }

        foreach (GameObject status in statusOfDoors)
        {
            if (state != -2)
            {
                if (status.GetComponent<statusOfDoor>().countOfTeleport != 0 && status.GetComponent<statusOfDoor>().state == state)
                {
                    status.GetComponent<SpriteRenderer>().color = new Color(255, 21, 8);
                }

                if (status.GetComponent<statusOfDoor>().state != state || status.GetComponent<statusOfDoor>().countOfTeleport == 0)
                {
                    status.GetComponent<SpriteRenderer>().color = new Color(100, 100, 100);
                }

                if (status.GetComponent<statusOfDoor>().isFinish)
                {
                    status.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                }
            }
        }

        statistic.SetText(stat + "/" + allCountOfDoors);
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

    private void RemoveMan()
    {
        foreach (GameObject statusOfD in statusOfDoors)
        {
            if (gameManager.state == statusOfD.GetComponent<statusOfDoor>().state)
            {
                Vector3 pos = statusOfD.GetComponent<Transform>().position;
                man.GetComponent<Transform>().position = new Vector3(pos.x - 0.4f, pos.y, pos.z);
            }
        }
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
            }

            timer.SetText(_minutes.ToString() + ":" + _seconds.ToString());
            yield return new WaitForSeconds(1);
        }
    }
}
