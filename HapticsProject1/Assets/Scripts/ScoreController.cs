using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int i = 0;
    public float score = 0f;
    public float now = 0f;
    private float[] timing = new float[10] { 1.0f, 4.0f, 7.0f, 10.0f, 14.0f,17.0f,20.0f,23.0f,26.0f,29.0f };//押す、離す時刻が交互に格納されたCSVを想定(今は5つのノーツ)
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        now += Time.deltaTime;//現在の時刻取得
        GameObject.Find("Timer").GetComponent<Text>().text = now.ToString("F2"); //時刻ひょうじ
        while(now>=timing[i] && now <= timing[i + 1])
        {
            ScoreI();
            if(now > timing[i + 1])
            {
                i += 1;
            }
        }
        ScoreD();
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

