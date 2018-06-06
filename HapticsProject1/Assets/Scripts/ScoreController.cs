using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public float score = 0f;
    public float now = 0f;
    private float start = 10.0f;//入力開始時刻
    private float end = 16.0f;//入力終了時刻
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        now += Time.deltaTime;//現在の時刻取得
        GameObject.Find("Timer").GetComponent<Text>().text = now.ToString("F2"); //時刻ひょうじ
        if (now >= start && now <= end)
        {
            ScoreI();
        }
        else
        {
            ScoreD();
        }

    }
    void ScoreI()//入力すべきタイミングでの判定と点数表示
    {
        if (Input.GetKey(KeyCode.Space))
        {
            score += 0.05f;

            GameObject.Find("Comment").GetComponent<Text>().text="Good";
            GameObject.Find("ScoreText").GetComponent<Text>().text= score.ToString("F0");

        }
        else
        {
            if(score > 0)
            {
                score -= 0.05f;
                GameObject.Find("Comment").GetComponent<Text>().text = "Bad";
                GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");

            }
            else
            {
                GameObject.Find("Comment").GetComponent<Text>().text = "Bad";
                GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
            }
            
        }
    }
    void ScoreD()//入力してはならない時の判定と点数表示
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            GameObject.Find("Comment").GetComponent<Text>().text ="Bad";
            GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");

        }
        else
        {
            GameObject.Find("Comment").GetComponent<Text>().text = "";
            GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");

        }
    }
}

