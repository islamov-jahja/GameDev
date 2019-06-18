using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.scripts;
using System;

public class restartInResultScene : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {	
		GameManager gameManager = GameManager.GetInstance();

        for (int i = 0; i < gameManager.levelsAndRatings.Count; i++)
        {
            if (gameManager.lastLevel == Convert.ToInt32(gameManager.levelsAndRatings[i].Split('*')[0]))
            {
                SceneManager.LoadScene(Convert.ToInt32(gameManager.levelsAndRatings[i].Split('*')[1].Split(':')[1]));
            }
        }
    }

}
