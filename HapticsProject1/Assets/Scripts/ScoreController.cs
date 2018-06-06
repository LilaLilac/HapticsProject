using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public float now = 0f;
    public float start = 1.0f;//入力開始時刻
    public float end = 5.0f;//入力終了時刻
    int score = 0;//スコア
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        now += Time.deltaTime;//現在の時刻取得
        //Debug.Log(now);
        if (now >= start && now <= end)
        {
            ScoreI();
        }
        else
        {
            ScoreD();
        }
    }
    void ScoreI()//入力すべきタイミングでの判定
    {
        if (Input.GetKey(KeyCode.Space))
        {

            GetComponent<Text>().text="Good";

        }
        else
        {
            GetComponent<Text>().text="Bad";
            if (score > 0)
            {
                score -= 1;
            }
        }
    }
    void ScoreD()//入力してはならない時の判定
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Text>().text ="Bad";
        }
        else
        {
            GetComponent<Text>().text = "";
        }
    }
}

