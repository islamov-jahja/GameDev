using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    public bool wasSelected = false;
    public int _state = -1;
    public int[] rooms;

    private void Start()
    {
        if (wasSelected)
        {
            GameObject[] mainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
            mainCamera[0].GetComponent<mainScript>().keys.Add(this);
        }
    }

    private void OnMouseDown()
    {
        if(!wasSelected && _state == GameManager.GetInstance().state)
        {
            transform.localScale = new Vector3(0.0584267f, 0.05450419f, 1f);
            Debug.Log(_state + ":" + GameManager.GetInstance().state);
            wasSelected = true;
            GameObject[] mainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
            Vector3 newPos = mainCamera[0].GetComponent<mainScript>()._positionToInsert;
            transform.position = newPos;
            mainCamera[0].GetComponent<mainScript>()._positionToInsert.x += mainCamera[0].GetComponent<mainScript>().delta/2.6f;
            mainCamera[0].GetComponent<mainScript>().keys.Add(this);
        }
    }
}
