using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Levels : MonoBehaviour {

    // Use this for initialization
    const float START_X = 797.4f;
    const float START_Y = 626.4526f;
    const float COORD_Z = 400.2f;
    const float QUAT_X = 6.676f;
    const float QUAT_Y = -97.635f;
    const float QUAT_Z = 42.861f;

    float forX = START_X;
    float forY = START_Y;
    public GameObject obj;
    int levelG;
    StreamReader level;
    int bricks = 0;
    string line;
    void Start()
    {
        levelG = PlayerPrefs.GetInt("level");
        if (levelG == 1)
            level = new StreamReader("E:\\практика\\Arcanoid\\Assets\\levels\\level1.txt");
        else if (levelG == 2)
            level = new StreamReader("E:\\практика\\Arcanoid\\Assets\\levels\\level2.txt");
        else if (levelG == 3)
            level = new StreamReader("E:\\практика\\Arcanoid\\Assets\\levels\\level3.txt");

        while (!level.EndOfStream)
        {
            line = level.ReadLine();

            for (int i = 0; i < line.Length; i++)
                if (line[i] == 'X')
                {
                    bricks++;
                    Instantiate(obj, new Vector3(forX, forY, COORD_Z), obj.transform.rotation);
                    forX += 28.8f;
                }else
                {
                    forX += 28.8f;
                }

            forX = START_X;
            forY -= 17.6526f;
        }

        Destroy(obj);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
