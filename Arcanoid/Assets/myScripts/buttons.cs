using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

    // Use this for initialization
    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void newGame()
    {
        SceneManager.LoadScene(1);
    }

    public void level1()
    {
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(2);
    }

    public void level2()
    {
        PlayerPrefs.SetInt("level", 2);
        SceneManager.LoadScene(2);
    }

    public void level3()
    {
        PlayerPrefs.SetInt("level", 3);
        SceneManager.LoadScene(2);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
