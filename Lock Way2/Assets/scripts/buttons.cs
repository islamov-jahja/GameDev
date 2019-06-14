using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.scripts;
using System.IO;

public class buttons : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameManager.GetInstance();
    }

    public void Exit()
    {
        StreamWriter writer = new StreamWriter("userData.txt");
        GameManager gameManager = GameManager.GetInstance();

        foreach(string level in gameManager.levelsAndRatings)
        {
            writer.WriteLine(level);
        }

        writer.Close();
        Application.Quit();
    }

    public void Levels()
    {
        SceneManager.LoadScene(2);
    }

    public void continueGame()
    {
        SceneManager.LoadScene(GameManager.GetInstance().lastLevel);
    }
	
	public void help()
    {
        SceneManager.LoadScene(4);
    }
}
