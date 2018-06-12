using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreController : MonoBehaviour
{
    public float score = 0f;
    public float now = 0f;
    public int i = 0;
    GameObject azisai;

    public GameObject flower;

    private float[] _start;
    private float[] _end;

    private int _notesCount = 0;
    public string filePass; //ここに読み込む譜面を入れる

    void Start()
    {
        _start = new float[1024];
        _end = new float[1024];
        LoadCSV();
    }

    void Update()
    {
        now += Time.deltaTime;//現在の時刻取得
        GameObject.Find("Timer").GetComponent<Text>().text = now.ToString("F2"); //時刻ひょうじ
        Debug.Log(now);
        Debug.Log(_notesCount);
        if (now >= _start[_notesCount] && now <= _end[_notesCount])
        {
            ScoreI();

        }
        else
            ScoreD();
        if (GameObject.Find("Comment").GetComponent<Text>().text == "Good" && azisai == null)
        {
            float px = Random.Range(-6.0f,6.0f);
            float py = Random.Range(-6.0f,6.0f);
            azisai = Instantiate(flower, new Vector3(px,py,0), Quaternion.identity) as GameObject;//Goodでゲームオブジェクトフェードイン
        }
        if(now > _end[_notesCount])
        {
            _notesCount += 1;
           

        }
    }

    void ScoreI()//入力すべきタイミングでの判定と点数表示
    {
        if (Input.GetKey(KeyCode.Space))
        {
            score += 0.05f;

            GameObject.Find("Comment").GetComponent<Text>().text = "Good";
            GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
            

        }
        else
        {
            if (score > 0)
            {
                score -= 0.05f;
                GameObject.Find("Comment").GetComponent<Text>().text = "Miss";
                GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");

            }
            else
            {
                GameObject.Find("Comment").GetComponent<Text>().text = "Miss";
                GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
            }
            
        }
    }
    void ScoreD()//入力してはならない時の判定と点数表示
    {
        if (Input.GetKey(KeyCode.Space))
        {

            GameObject.Find("Comment").GetComponent<Text>().text = "Bad";
            GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");

        }
        else
        {
            GameObject.Find("Comment").GetComponent<Text>().text = "";
            GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");

        }
        
    }

    void LoadCSV()
    {
        int i = 0, j;
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {

            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (j = 0; j < values.Length; j++)
            {
                _start[i] = float.Parse(values[0]);
                _end[i] = float.Parse(values[1]);
                
            }
            i++;
        }
    }
}

