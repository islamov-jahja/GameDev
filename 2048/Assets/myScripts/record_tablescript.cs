using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.IO;

public class record_tablescript : MonoBehaviour {
    public Text[] names = new Text[5];
    public Text[] values = new Text[5];
    SortedDictionary<int, string> records = new SortedDictionary<int, string>();
    StreamReader a = new StreamReader("records.txt");
    // Use this for initialization
    int index = 0;
    void Start () {
        for (int i = 0; i < 5; i++)
            records.Add(Convert.ToInt32(a.ReadLine()), a.ReadLine());
        a.Close();

        foreach (var x in records)
        {
            names[index].text = x.Value;
            values[index].text =Convert.ToString(x.Key);
            index++;
        }
    }
}
