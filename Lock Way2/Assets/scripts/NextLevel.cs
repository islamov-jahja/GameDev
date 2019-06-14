using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.scripts;
using System;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        SceneManager.LoadScene(GetNextLevel());
    }

    private int GetNextLevel()
    {
        GameManager gameManager = GameManager.GetInstance();

        for (int i = 0; i < gameManager.levelsAndRatings.Count; i++)
        {
            if (gameManager.lastLevel == Convert.ToInt32(gameManager.levelsAndRatings[i].Split('*')[0]))
            {
                if (i != gameManager.levelsAndRatings.Count - 1)
                {
                    return Convert.ToInt32(gameManager.levelsAndRatings[i+1].Split('*')[1].Split(':')[1]);
                }
            }
        }

        return gameManager.lastLevel;
    }
}
