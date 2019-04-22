using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class main : MonoBehaviour{
    bool isLoad = false;
    SortedDictionary<int, string> records = new SortedDictionary<int, string>();
    StreamReader a = new StreamReader("records.txt");
    public Text bestScore;
    public Text scoreText;
    int[,] reserveMechanism = new int[5, 5];
    int[,] mainMechanism = new int[5, 5];
    public Text[] arrOftext = new Text[16];
    public GameObject scene;
    public GameObject[] arrOFGameObject = new GameObject[16];
    Text[,] blockText = new Text[5, 5];
    public GameObject[,] blocksObj = new GameObject[5, 5];
    bool check = false;
    int scores = 0;
    int bestScoreInt = 0;
    int reserveScore = 0;
    int reserveScore2 = 0;
    bool checBack = true;

    void Start() {
        for (int i = 0; i < 5; i++)
            records.Add(Convert.ToInt32(a.ReadLine()), a.ReadLine());

        foreach (var x in records)
            bestScoreInt = x.Key;

        int z = 0;

        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 5; j++)
            {
                blocksObj[i, j] = arrOFGameObject[z];
                blockText[i, j] = arrOftext[z];
                z++;
                blocksObj[i, j].SetActive(false);
            }

        GetRandom(ref mainMechanism);
        GetRandom(ref mainMechanism);
        RenderScene(ref mainMechanism, ref blockText, ref blocksObj, scoreText, scores, bestScoreInt);
        copyArr(ref reserveMechanism, mainMechanism);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            copyArr(ref reserveMechanism, mainMechanism);
            reserveScore = scores;
            UpwardMovement(ref mainMechanism);
            if (!IsEqualityArray(reserveMechanism, mainMechanism))
            {
                GetRandom(ref mainMechanism);
                RenderScene(ref mainMechanism, ref blockText, ref blocksObj, scoreText, scores, bestScoreInt);
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            copyArr(ref reserveMechanism, mainMechanism);
            reserveScore = scores;
            DownWardMovement(ref mainMechanism);
            if (!IsEqualityArray(reserveMechanism, mainMechanism))
            {
                GetRandom(ref mainMechanism);
                RenderScene(ref mainMechanism, ref blockText, ref blocksObj, scoreText, scores, bestScoreInt);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            copyArr(ref reserveMechanism, mainMechanism);
            reserveScore = scores;
            RightWardMovement(ref mainMechanism);
            if (!IsEqualityArray(reserveMechanism, mainMechanism))
            {
                GetRandom(ref mainMechanism);
                RenderScene(ref mainMechanism, ref blockText, ref blocksObj, scoreText, scores, bestScoreInt);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            copyArr(ref reserveMechanism, mainMechanism);
            reserveScore = scores;
            LeftWardMovement(ref mainMechanism);
            if (!IsEqualityArray(reserveMechanism, mainMechanism))
            {
                GetRandom(ref mainMechanism);
                RenderScene(ref mainMechanism, ref blockText, ref blocksObj, scoreText, scores, bestScoreInt);
            }
        }
        reserveScore2 = scores;
        if (IsEnd(mainMechanism))
        {
            scores = reserveScore2;
            foreach (var x in records)
                if (scores > x.Key)
                {
                    PlayerPrefs.SetInt("scores", scores);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(4);
                    a.Close();
                    isLoad = true;
                }
            if (!isLoad)
                SceneManager.LoadScene(3);
        }
        else
            scores = reserveScore2;

        if (scores > bestScoreInt)
            bestScoreInt = scores;
    }


    bool IsEnd(int[,] mainMechanism)
    {
        int[,] copyMainMechanism = new int[5, 5];
        copyArr(ref copyMainMechanism, mainMechanism);
        UpwardMovement(ref copyMainMechanism);
        if (!IsEqualityArray(copyMainMechanism, mainMechanism))
            return (false);
        else
        {
            DownWardMovement(ref copyMainMechanism);
            if (!IsEqualityArray(copyMainMechanism, mainMechanism))
                return false;
            else
            {
                LeftWardMovement(ref copyMainMechanism);
                if (!IsEqualityArray(copyMainMechanism, mainMechanism))
                    return false;
                else
                {
                    RightWardMovement(ref copyMainMechanism);
                    if (!IsEqualityArray(copyMainMechanism, mainMechanism))
                        return false;
                    else
                        return true;
                }
            }
        }

    }

    void GetRandom(ref int[,] mainMechanism)
    {
        int k = 0, z = 0;
        System.Random rnd = new System.Random();
        int indexRandom = 0;
        List<int> randomList = new List<int>();
        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 5; j++)
            {
                if (mainMechanism[i, j] == 0)
                {
                    k = i * 10 + j;
                    randomList.Add(k);
                }
            }
        indexRandom = rnd.Next(randomList.Count);
        k = randomList[indexRandom];
        z = k % 10;
        k = (k / 10) % 10;
        mainMechanism[k, z] = GetRandomScore();
    }

    void RenderScene(ref int[,] mainMechanism, ref Text[,] blockText, ref GameObject[,] blocksObj, Text scoreText, int scores, int bestScoreInt)
    {
        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 5; j++)
            {
                if (mainMechanism[i, j] != 0)
                {
                    blockText[i, j].text = mainMechanism[i, j].ToString();
                    blocksObj[i, j].SetActive(true);
                }
                else
                    blocksObj[i, j].SetActive(false);
            }
        scoreText.text = "Scores: " + scores;
        bestScore.text = "Best Score: " + bestScoreInt;
    }

    int GetRandomScore()
    {
        System.Random rnd = new System.Random();
        int[] twoOrFour = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 4 };
        int indexRandom = 0;
        indexRandom = rnd.Next(10);
        return (twoOrFour[indexRandom]);
    }

    void UpwardMovement(ref int[,] mainMechanism)
    {
        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 5; j++)
            {
                if(i == 2)
                {
                    Swap(ref mainMechanism, i, j, i - 1, j);
                }
                else if(i == 3)
                {
                    Swap(ref mainMechanism, i, j, i - 1, j);
                    Swap(ref mainMechanism, i - 1, j, i - 2, j);
                }
                else if (i == 4)
                {
                    Swap(ref mainMechanism, i, j, i - 1, j);
                    Swap(ref mainMechanism, i - 1, j, i - 2, j);
                    Swap(ref mainMechanism, i - 2, j, i - 3, j);
                }
            }

        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 5; j++)
            {
                if (i != 4)
                {
                    check =  ChangeOfValueUp(ref mainMechanism, i, j, i + 1, j, ref scores);
                    if (check == false && i != 3)
                    {
                        if (mainMechanism[i+1, j] == 0)
                            check = ChangeOfValueUp(ref mainMechanism, i, j, i + 2, j, ref scores);
                        if (check == false && i != 2)
                            if (mainMechanism[i + 2, j] == 0)
                                ChangeOfValueUp(ref mainMechanism, i, j, i + 3, j, ref scores);
                    }
                }
            }

        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 5; j++)
            {
                if (i == 2)
                {
                    Swap(ref mainMechanism, i, j, i - 1, j);
                }
                else if (i == 3)
                {
                    Swap(ref mainMechanism, i, j, i - 1, j);
                    Swap(ref mainMechanism, i - 1, j, i - 2, j);
                }
                else if (i == 4)
                {
                    Swap(ref mainMechanism, i, j, i - 1, j);
                    Swap(ref mainMechanism, i - 1, j, i - 2, j);
                    Swap(ref mainMechanism, i - 2, j, i - 3, j);
                }
            }
    }

    void DownWardMovement(ref int[,] mainMechanism)
    {
        for (int i = 4; i > 0; i--)
            for (int j = 4; j > 0; j--)
            {
                if (i == 3)
                {
                    Swap(ref mainMechanism, i, j, i + 1, j);
                }
                else if (i == 2)
                {
                    Swap(ref mainMechanism, i, j, i + 1, j);
                    Swap(ref mainMechanism, i + 1, j, i + 2, j);
                }
                else if (i == 1)
                {
                    Swap(ref mainMechanism, i, j, i + 1, j);
                    Swap(ref mainMechanism, i + 1, j, i + 2, j);
                    Swap(ref mainMechanism, i + 2, j, i + 3, j);
                }
            }

        for (int i = 4; i > 0; i--)
            for (int j = 4; j > 0; j--)
            {
                if (i != 1)
                {
                    check = ChangeOfValueUp(ref mainMechanism, i, j, i - 1, j, ref scores);
                    if (check == false && i != 2)
                    {
                        if (mainMechanism[i - 1, j] == 0)
                            check = ChangeOfValueUp(ref mainMechanism, i, j, i - 2, j, ref scores);
                        if (check == false && i != 3)
                            if (mainMechanism[i - 2, j] == 0)
                                ChangeOfValueUp(ref mainMechanism, i, j, i - 3, j, ref scores);
                    }
                }
            }

        for (int i = 4; i > 0; i--)
            for (int j = 4; j > 0; j--)
            {
                if (i == 3)
                {
                    Swap(ref mainMechanism, i, j, i + 1, j);
                }
                else if (i == 2)
                {
                    Swap(ref mainMechanism, i, j, i + 1, j);
                    Swap(ref mainMechanism, i + 1, j, i + 2, j);
                }
                else if (i == 1)
                {
                    Swap(ref mainMechanism, i, j, i + 1, j);
                    Swap(ref mainMechanism, i + 1, j, i + 2, j);
                    Swap(ref mainMechanism, i + 2, j, i + 3, j);
                }
            }
    }

    void RightWardMovement(ref int[,] mainMechanism)
    {
        for (int j = 4; j > 0; j--)
            for (int i = 4; i > 0; i--)
            {
                if (j == 3)
                {
                    Swap(ref mainMechanism, i, j, i, j+1);
                }
                else if (j == 2)
                {
                    Swap(ref mainMechanism, i, j, i, j + 1);
                    Swap(ref mainMechanism, i, j+1, i, j+2);
                }
                else if (j == 1)
                {
                    Swap(ref mainMechanism, i, j, i, j+1);
                    Swap(ref mainMechanism, i, j + 1, i, j + 2);
                    Swap(ref mainMechanism, i, j + 2, i, j + 3);
                }
            }

        for (int j = 4; j > 0; j--)
            for (int i = 4; i > 0; i--)
            {
                if (j != 1)
                {
                    check = ChangeOfValueUp(ref mainMechanism, i, j, i, j - 1, ref scores);
                    if (check == false && j != 2)
                    {
                        if (mainMechanism[i, j - 1] == 0)
                            check = ChangeOfValueUp(ref mainMechanism, i, j, i, j - 2, ref scores);
                        if (check == false && j != 3)
                            if (mainMechanism[i, j - 2] == 0)
                                ChangeOfValueUp(ref mainMechanism, i, j, i, j - 3, ref scores);
                    }
                }
            }

        for (int j = 4; j > 0; j--)
            for (int i = 4; i > 0; i--)
            {
                if (j == 3)
                {
                    Swap(ref mainMechanism, i, j, i, j + 1);
                }
                else if (j == 2)
                {
                    Swap(ref mainMechanism, i, j, i, j + 1);
                    Swap(ref mainMechanism, i, j + 1, i, j + 2);
                }
                else if (j == 1)
                {
                    Swap(ref mainMechanism, i, j, i, j + 1);
                    Swap(ref mainMechanism, i, j + 1, i, j + 2);
                    Swap(ref mainMechanism, i, j + 2, i, j + 3);
                }
            }
    }

    void LeftWardMovement(ref int[,] mainMechanism)
    {
        for (int j = 1; j < 5; j++)
            for (int i = 1; i < 5; i++)
            {
                if (j == 2)
                {
                    Swap(ref mainMechanism, i, j, i, j - 1);
                }
                else if (j == 3)
                {
                    Swap(ref mainMechanism, i, j, i, j - 1);
                    Swap(ref mainMechanism, i, j - 1, i, j - 2);
                }
                else if (j == 4)
                {
                    Swap(ref mainMechanism, i, j, i, j - 1);
                    Swap(ref mainMechanism, i, j - 1, i, j - 2);
                    Swap(ref mainMechanism, i, j - 2, i, j - 3);
                }
            }

        for (int j = 1; j < 5; j++)
            for (int i = 1; i < 5; i++)
            {
                if (j != 4)
                {
                    check = ChangeOfValueUp(ref mainMechanism, i, j, i, j + 1, ref scores);
                    if (check == false && j != 3)
                    {
                        if (mainMechanism[i, j + 1] == 0)
                            check = ChangeOfValueUp(ref mainMechanism, i, j, i, j + 2, ref scores);
                        if (check == false && j != 2)
                            if (mainMechanism[i, j + 2] == 0)
                                ChangeOfValueUp(ref mainMechanism, i, j, i, j + 3, ref scores);
                    }
                }
            }

        for (int j = 1; j < 5; j++)
            for (int i = 1; i < 5; i++)
            {
                if (j == 2)
                {
                    Swap(ref mainMechanism, i, j, i, j - 1);
                }
                else if (j == 3)
                {
                    Swap(ref mainMechanism, i, j, i, j - 1);
                    Swap(ref mainMechanism, i, j - 1, i, j - 2);
                }
                else if (j == 4)
                {
                    Swap(ref mainMechanism, i, j, i, j - 1);
                    Swap(ref mainMechanism, i, j - 1, i, j - 2);
                    Swap(ref mainMechanism, i, j - 2, i, j - 3);
                }
            }
    }

    bool ChangeOfValueUp(ref int[,] mainMechanism, int index1X, int index1Y, int index2X, int index2Y, ref int scores)  //массив, который меняем, (координаты данной ячейки)(координаты следующей ячейки))
    {
        if (mainMechanism[index2X, index2Y] == mainMechanism[index1X, index1Y] && mainMechanism[index1X, index1Y] != 0)
        {
            mainMechanism[index1X, index1Y] = mainMechanism[index1X, index1Y] * 2;
            scores += mainMechanism[index1X, index1Y];
            mainMechanism[index2X, index2Y] = 0;
            return (true);
        }
        else
            return (false);
    }

    void Swap(ref int[,] mainMechanism, int index1X, int index1Y, int index2X, int index2Y)//массив, который меняем, (координаты данной ячейки)(координаты предыдущей ячейки))
    {
        if (mainMechanism[index2X, index2Y] == 0)
        {
            mainMechanism[index2X, index2Y] = mainMechanism[index1X, index1Y];
            mainMechanism[index1X, index1Y] = 0;
        }
    }

    void copyArr(ref int[,] arr2, int[,] arr1)
    {
        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 5; j++)
                arr2[i, j] = arr1[i, j];
    }

    bool IsEqualityArray(int[,] arr1, int[,] arr2)
    {
        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 5; j++)
                if (arr1[i, j] != arr2[i, j])
                    return (false);
        return (true);
    }

    public void BackButton()
    {
        copyArr(ref mainMechanism, reserveMechanism);
        scores = reserveScore;
        RenderScene(ref mainMechanism, ref blockText, ref blocksObj, scoreText, scores, bestScoreInt);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}