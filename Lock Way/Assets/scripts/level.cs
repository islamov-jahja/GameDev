using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelInt = 0;
    public int scene = 0;
    public int countOfStar = 0;

    public GameObject[] stars;
    public TextMeshProUGUI levelText;

    void Start()
    {   
        
    }

    private void Update()
    {
        Debug.Log(levelInt + " " + scene);
    }

    private void OnMouseDown()
    {
        if (scene != -1)
            SceneManager.LoadScene(scene);
    }

    public void RenderData()
    {
        levelText.text = levelInt.ToString();

        for (int i = 0; i < 3; i++)
        {
            stars[i].GetComponent<SpriteRenderer>().color = new Color32(159, 107, 43, 255);
        }

        for (int i = 0; i < countOfStar; i++)
        {
            stars[i].GetComponent<SpriteRenderer>().color = new Color32(255, 222, 50, 255);
        }
    }

}
