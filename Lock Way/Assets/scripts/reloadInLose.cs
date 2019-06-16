using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;
using UnityEngine.SceneManagement;

public class reloadInLose : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        GameManager gameManager = GameManager.GetInstance();
        SceneManager.LoadScene(gameManager.lastLevel);
    }
}
