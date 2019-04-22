using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scores : MonoBehaviour {

    // Use this for initialization
    public Text score;
    int scoress;
	void Start () {
        scoress = PlayerPrefs.GetInt("score");
        score.text = "your scores: " + scoress;
	}
}
