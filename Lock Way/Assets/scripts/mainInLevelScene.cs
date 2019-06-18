using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;
using System;
using UnityEngine.SceneManagement;

public class mainInLevelScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] levels;
    public int page = 1;
    public int maxPages = 1;
    public int lastCount = 0;

    void Start()
    {
        GameManager gameManager = GameManager.GetInstance();
        maxPages = (gameManager.levelsAndRatings.Count / 6) + 1;
        lastCount = gameManager.levelsAndRatings.Count % 6;
        LoadPage(1);
    }

    private void LoadPage(int page)
    {
        int startIndex = ((6 * (page - 1)) + 1) - 1;

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }

        if (page == maxPages)
        {
            for (int i = 5; i >= 5 - (5 - lastCount); i--)
            {
                levels[i].GetComponent<SpriteRenderer>().color = new Color32(156, 154, 154, 255);
                levels[i].GetComponent<level>().levelInt = 0;
                levels[i].GetComponent<level>().countOfStar = 0;
                levels[i].GetComponent<level>().scene = -1;
                levels[i].GetComponent<level>().RenderData();
            }

            for (int i = 0; i < lastCount; i++)
            {
                levels[i].GetComponent<level>().levelInt = GetLevel(startIndex);
                levels[i].GetComponent<level>().scene = GetScene(startIndex);
                levels[i].GetComponent<level>().countOfStar = GetCountOfStars(startIndex);
                startIndex++;
                levels[i].GetComponent<level>().RenderData();
            }
        }
        else
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].GetComponent<level>().levelInt = GetLevel(startIndex);
                levels[i].GetComponent<level>().scene = GetScene(startIndex);
                levels[i].GetComponent<level>().countOfStar = GetCountOfStars(startIndex);
                startIndex++;
                levels[i].GetComponent<level>().RenderData();
            }
        }

    }

    private int GetCountOfStars(int index)
    {
        GameManager gameManager = GameManager.GetInstance();
        string[] arr = gameManager.levelsAndRatings[index].Split('*');
        return Convert.ToInt32(arr[1].Split(':')[2].Length);
    }

    private int GetScene(int index)
    {
        GameManager gameManager = GameManager.GetInstance();
        string[] arr = gameManager.levelsAndRatings[index].Split('*');
        return Convert.ToInt32(arr[1].Split(':')[1]);
    }

    private int GetLevel(int index)
    {
        GameManager gameManager = GameManager.GetInstance();
        return Convert.ToInt32(gameManager.levelsAndRatings[index].Split('*')[0]);
    }

    public void NextPage()
    {
        if (page != maxPages)
        {
            page++;
            LoadPage(page);
        }
    }

    public void PreviousPage()
    {
        if (page != 1)
        {
            page--;
            LoadPage(page);
        }
    }

    public void CleanStatistic()
    {
        GameManager gameManager = GameManager.GetInstance();
        String newLine;

        for(int i = 0; i < gameManager.levelsAndRatings.Count; i++)
        {
            newLine = gameManager.levelsAndRatings[i].Split('*')[0];
            newLine += "*0-50:" + gameManager.levelsAndRatings[i].Split('*')[1].Split(':')[1] + ":";
            gameManager.levelsAndRatings[i] = newLine;
        }

        SceneManager.LoadScene(2);
    }
}
