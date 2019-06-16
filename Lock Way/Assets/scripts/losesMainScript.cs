using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;
using TMPro;

public class losesMainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI timeText;
    void Start()
    {
        timeText.text = GameManager.GetInstance().minutesResult + ":" + GameManager.GetInstance().secondsResult;
    }
}
