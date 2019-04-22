using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndWithTables()
    {
        SceneManager.LoadScene(4);
    }

    public void End()
    {
        SceneManager.LoadScene(3);
    }

    public void Table()
    {
        SceneManager.LoadScene(2);
    }
}
