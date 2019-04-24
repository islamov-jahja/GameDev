using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class mainScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager = GameManager.GetInstance();
    private string state;
    private int allCountOfDoors;

    void Start()
    {
        allCountOfDoors = GameObject.FindGameObjectsWithTag("Player").Length;
        gameManager.state = "3";
        state = "1";
    }

    // Update is called once per frame
    void Update()
    {
        if (state != gameManager.state)
        {
            ChangeColorOfDoors();
            state = gameManager.state;
        }

        if (IsWin())
        {
            Debug.Log("Молодец, победил!!!");
        }
    }


    private void ChangeColorOfDoors()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject door in doors)
        {
            if (!gameManager.steps.Contains(door))
            {
                door.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255f, 255f);
            }
        }

        foreach (GameObject door in doors)
        {
            if ((door.GetComponent<door>().codeZoneA == gameManager.state || door.GetComponent<door>().codeZoneB == gameManager.state) 
                && !gameManager.steps.Contains(door))
            {
                door.GetComponent<SpriteRenderer>().color = new Color(52f, 255f, 8f, 255f);
            }
        }
    }

    private bool IsWin()
    {
        return (allCountOfDoors == gameManager.steps.Count);
    }
}
