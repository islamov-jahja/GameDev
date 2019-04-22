using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.IO;

public class saveScores : MonoBehaviour {
    bool isSave = false;
    int scores;
    public Text yourScore;
    public Text myText;
    string name;
    SortedDictionary<int, string> records = new SortedDictionary<int, string>();
    StreamReader a = new StreamReader("records.txt");
    int index = 0;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
            records.Add(Convert.ToInt32(a.ReadLine()), a.ReadLine());

        scores = PlayerPrefs.GetInt("scores");
        yourScore.text = "Your scores: " + scores;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        a.Close();
    }
    // Use this for initialization
    public void Ok()
    {
		if (!isSave)
		{
            StreamWriter b = new StreamWriter("records.txt", false);
            name = myText.text;
            records.Add(scores, name);
            foreach (var x in records)
            {
                if (index > 0)
                {
                    b.WriteLine(x.Key);
                    b.WriteLine(x.Value);
                }
                index++;
            }
            b.Close();
		}
		isSave = true;
    }
}
