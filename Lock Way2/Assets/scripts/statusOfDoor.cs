using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.scripts;

public class statusOfDoor : MonoBehaviour
{
    public bool isFinish;
    public Text text;
    public int state;
    public int countOfTeleport;

    void Start()
    {
        GameObject[] mainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        if (isFinish)
        {
            mainCamera[0].GetComponent<mainScript>().winState = state;
        }

        if (text != null)
        {
            countOfTeleport = Convert.ToInt32(text.text);
        }
        else
        {
            countOfTeleport = 0;
        }
    }

    private void OnMouseDown()
    {
        GameManager gameManager = GameManager.GetInstance();
        //условие на цвет

        if (gameManager.state == state && countOfTeleport != 0)
        {
            GameObject[] mainCamera = GameObject.FindGameObjectsWithTag("MainCamera");

            foreach (GameObject obj in mainCamera[0].GetComponent<mainScript>().statusOfDoors)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(0, 255, 254);
                gameManager.state = -2;
            }

            countOfTeleport--;
            text.text = countOfTeleport.ToString();
        }

        if (GetComponent<SpriteRenderer>().color == new Color(0, 255, 254))
        {
            gameManager.state = state;
        }
    }
}
