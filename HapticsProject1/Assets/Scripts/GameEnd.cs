using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameEnd : MonoBehaviour {//ゲームが終わったら結果を表示する

    // Use this for initialization

    ScoreController EndScore;
    GameObject scoreController;
    float result;
    int i;
    string achievement;


    void Start()
    {
        scoreController = GameObject.Find("ScoreController");
        EndScore = scoreController.GetComponent<ScoreController>();

        
    }

    void Update()
    {
        result = EndScore.score;
        i = EndScore._notesCount;
        
        if (EndScore._start[i] == 0)
        {
            Invoke("Result", 5.0f);
        }
    }
    void Result()//ゲーム終了時のエフェクト
    {
        GameObject.Find("Result").GetComponent<Text>().text = result.ToString("F0");
       
        if (result > 30)
        {
            GameObject.Find("Achievement").GetComponent<Text>().text = "Congratulation!!";
        }
        else if (result > 15)
        {
            GameObject.Find("Achievement").GetComponent<Text>().text = "Great!!";
        }
        else{
            GameObject.Find("Achievement").GetComponent<Text>().text = "Fight!!";
        }
    }
}
