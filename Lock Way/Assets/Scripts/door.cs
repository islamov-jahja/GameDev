using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class door : MonoBehaviour
{
    public string uid;
    public string codeZoneA;
    public string codeZoneB;
    private GameManager gameManager = GameManager.GetInstance();

    public void Start()
    {
        uid = Guid.NewGuid().ToString();
    }

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if ((gameManager.state == codeZoneA || gameManager.state == codeZoneB) && !gameManager.steps.Contains(gameObject))
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 255f);
            gameManager.steps.Push(gameObject);

            if (gameManager.state == codeZoneA)
                gameManager.state = codeZoneB;
            else
                gameManager.state = codeZoneA;
        }
    }
}
