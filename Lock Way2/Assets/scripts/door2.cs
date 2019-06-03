using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;

public class door2 : MonoBehaviour
{
    public string uid;
    public int codeZoneA;
    public int codeZoneB;
    public int countOfLives = 1;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 215, 47);//0 255 255 - зеленый
    }

    private void OnMouseDown()
    {
        GameManager gameManager = GameManager.GetInstance();
        if ((gameManager.state == codeZoneA || gameManager.state == codeZoneB) && countOfLives != 0)
        {
            countOfLives--;

            if (gameManager.state == codeZoneA)
                gameManager.state = codeZoneB;
            else
                gameManager.state = codeZoneA;
        }

        Debug.Log(gameManager.state);


    }
}
