using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.scripts;

public class restart : MonoBehaviour
{
    public int scene = 0;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        GameManager.GetInstance().lastLevel = scene;
        SceneManager.LoadScene(scene);
    }
}
