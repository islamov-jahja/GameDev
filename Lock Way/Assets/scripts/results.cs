using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.scripts;
using System;

public class results : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI bestTime;

    public GameObject[] stars;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.GetInstance();
        time.SetText(gameManager.minutesResult + ":" + gameManager.secondsResult);

        string level = GetLevel();
        SetBestResult(level);


        RenderResultStars();
    }

    private void SetBestResult(string level)
    {
        GameManager gameManager = GameManager.GetInstance();
        int minutes = Convert.ToInt32(level.Split('*')[1].Split(':')[0].Split('-')[0]);
        int seconds = Convert.ToInt32(level.Split('*')[1].Split(':')[0].Split('-')[1]);

        int localTime = gameManager.minutesResult * 60 + gameManager.secondsResult;
        int globalTime = minutes * 60 + seconds;

        if (localTime < globalTime)
        {
            bestTime.text = gameManager.minutesResult + ":" + gameManager.secondsResult;
            string newLine = level.Split('*')[0] + "*" + gameManager.minutesResult + "-" + gameManager.secondsResult + ":" + level.Split('*')[1].Split(':')[1] + ":" + GetResultInText();
            WriteNewData(newLine);
        }else
        {
            bestTime.text = minutes + ":" + seconds;
        }
    }

    private void WriteNewData(string newLevel)
    {
        GameManager gameManager = GameManager.GetInstance();
        for (int i = 0; i < gameManager.levelsAndRatings.Count; i++)
        {
            if (gameManager.levelsAndRatings[i].Split('*')[0] == newLevel.Split('*')[0])
                gameManager.levelsAndRatings[i] = newLevel;
        }
    }

    private string GetLevel()
    {
        GameManager gameManager = GameManager.GetInstance();

        foreach(string line in gameManager.levelsAndRatings)
        {
            if (gameManager.lastLevel == Convert.ToInt32(line.Split('*')[0]))
                return line;
        }

        return "";
    }

    private string GetResultInText()
    {
        GameManager gameManager = GameManager.GetInstance();

        if (gameManager.minutesResult < 1)
        {
            if (gameManager.secondsResult <= gameManager.results[0])
                return "+++";
            else if (gameManager.secondsResult <= gameManager.results[1])
                return "++";
            else if (gameManager.secondsResult <= gameManager.results[2])
                return "+";
        }

        return "";
    }

    private void RenderResultStars()
    {
        string textResult = GetResultInText();
        int count = GetResultInText().Length;

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].GetComponent<SpriteRenderer>().color = new Color32(159, 107, 43, 255);
        }

        for (int i = 0; i < count; i++)
        {
            stars[i].GetComponent<SpriteRenderer>().color = new Color32(255, 222, 50, 255);
        }
        
    }

}
