using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

    public int great;
    public int good;
    public int bad;
    public int miss;
    public int score;
    public float percent;

    private int a; //仮の変数置き場
    private int b;
    private int c;
    private int d;
    private int e;
    private float f;

    GameObject Great;
    GameObject Good;
    GameObject Bad;
    GameObject Miss;
    GameObject Score;
    GameObject Percent;

    ScoreCounter finalscore;
    GameObject scoreCounter;

    // Use this for initialization
    void Start () {

        scoreCounter = GameObject.Find("ScoreCounter");
        finalscore = scoreCounter.GetComponent<ScoreCounter>();

        this.Great = GameObject.Find("GreatResult");
        this.Good = GameObject.Find("GoodResult");
        this.Bad = GameObject.Find("BadResult");
        this.Miss = GameObject.Find("MissResult");
        this.Score = GameObject.Find("ScoreResult");
        this.Percent = GameObject.Find("percent");

        great = finalscore.great;
        good = finalscore.good;
        bad = finalscore.bad;
        miss = finalscore.totalnotes - (great + good + bad);

        score = great * 100 + good * 50;

        percent = score / finalscore.totalnotes;

        a = 0;
        b = 0;
        c = 0;
        d = 0;
        e = 0;
        f = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (a < great)
        {
            a++;
        }
        if (b < good)
        {
            b++;
        }
        if (c < bad)
        {
            c++;
        }
        if (d < miss)
        {
            d++;
        }
        if (e < score)
        {
            e+=10;
        }
        if (f < percent)
        {
            f+=0.1f ;
        }
        else
        {
            f = percent;
        }

        this.Great.GetComponent<Text>().text = a.ToString("F0");
        this.Good.GetComponent<Text>().text = b.ToString("F0");
        this.Bad.GetComponent<Text>().text = c.ToString("F0");
        this.Miss.GetComponent<Text>().text = d.ToString("F0");
        this.Score.GetComponent<Text>().text = e.ToString("F0");

        this.Percent.GetComponent<Text>().text = f.ToString("F2");
    }
}
