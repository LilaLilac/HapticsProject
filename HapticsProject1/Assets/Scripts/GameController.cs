using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    SerialController serialcontroller;
    GameObject serial;

    public GameObject[] notes;
    
    public float[] _start;
    public float[] _end;
    public float[] _span;
    public float[] _posx1; //座標
    public float[] _posy1;
    public float[] _posx2;
    public float[] _posy2;
    

    public string filePass;
    public int _notesCount = 0; //ノーツ生成用
    public int _dummyCount = 0; //ガイド用ライン生成用

    private int _begin = 0; //押し始め判定
    private int _release = 0; //離すタイミング判定

    private AudioSource _audioSource;
    private float _startTime = 0;


    public float timeOffset = -1;

    private bool _isPlaying = false;
    public GameObject startButton;

    private bool _isHold = false;
    public float score = 0f;
    
    public GameObject great;
    public GameObject good;
    public GameObject bad;

    public int Great=0;
    public int Good=0;
    public int Bad=0;

    public float waitTime; 

    void Start()
    {
        serial = GameObject.Find("SerialController");
        serialcontroller = serial.GetComponent<SerialController>();

        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();

        _start = new float[1024];
        _end = new float[1024];
        _span = new float[1024];
        _posx1 = new float[1024];
        _posy1 = new float[1024];
        _posx2 = new float[1024];
        _posy2 = new float[1024];
       
        LoadCSV();
        _startTime = Time.time;
        
    }

    void Update()
    {
        if (_isPlaying)
        {
            GameObject.Find("Timer").GetComponent<Text>().text = GetMusicTime().ToString("F2");
            CheckNextNotes();
      
            if (serialcontroller.ReadData() == "1")　//押し始め判定
            {
                if (GetMusicTime() - _start[_begin]>=-0.1f && GetMusicTime() - _start[_begin]<= 0.1f)
                {
                    score += 100f;
              
                    GameObject.Find("Comment").GetComponent<Text>().text = "Great";
                    GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                    Instantiate(great, new Vector3(_posx1[_begin],_posy1[_begin],0),Quaternion.identity);
                    serialcontroller.Write("0");
                    Great++ ;

                    _begin++;
                }
                else if (GetMusicTime() - _start[_begin] >= -0.15f && GetMusicTime() - _start[_begin] <= 0.15f)
                {
                    score += 50f;

                    GameObject.Find("Comment").GetComponent<Text>().text = "Good";
                    GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                    Instantiate(good, new Vector3(_posx1[_begin], _posy1[_begin], 0), Quaternion.identity);
                    serialcontroller.Write("0");
                    Good++;

                    _begin++;
                }
                else if (GetMusicTime() - _start[_begin] >= -0.6f && GetMusicTime() - _start[_begin] <= 0.6f)
                {

                    GameObject.Find("Comment").GetComponent<Text>().text = "Bad";
                    GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                    Instantiate(bad, new Vector3(_posx1[_begin], _posy1[_begin], 0), Quaternion.identity);
                    serialcontroller.Write("1");
                    Bad++;

                    _begin++;
                }
                else
                {

                }
                _isHold = true;
            }

            if (serialcontroller.ReadData() == "1")
            {
                if (_isHold)
                {
                    if (GetMusicTime() - _end[_release] >= -0.1f && GetMusicTime() - _end[_release] <= 0.1f)
                    {
                        score += 100f;

                        GameObject.Find("Comment").GetComponent<Text>().text = "Great";
                        GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                        //パスの終わりにエフェクトを入れたい　保持リストを作っていないので別途読み込み
                        serialcontroller.Write("0");
                        Great++;

                        _release++;
                    }
                    else if (GetMusicTime() - _end[_release] >= -0.15f && GetMusicTime() - _end[_release] <= 0.15f)
                    {
                        score += 50f;

                        GameObject.Find("Comment").GetComponent<Text>().text = "Good";
                        GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                        serialcontroller.Write("0");
                        Good ++ ;

                        _release++;
                    }
                    else if (GetMusicTime() - _end[_release] >= -0.6f && GetMusicTime() - _end[_release] <= 0.6f)
                    {

                        GameObject.Find("Comment").GetComponent<Text>().text = "Bad";
                        GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                        serialcontroller.Write("1");
                        Bad++;

                        _release++;
                    }
                    else
                    {

                    }
                    _isHold = false;
                }
            }
            
        }
         //scoreText.text = _score.ToString();
    }

    public void StartGame()
    {
        waitTime = 0;
        startButton.SetActive(false);
        _startTime = Time.time;
        while (waitTime < 3.0f)
        {
            waitTime += Time.deltaTime;
        }

        _audioSource.Play();
        _isPlaying = true;
      
    }

    void CheckNextNotes()
    {
        while (_start[_dummyCount] + timeOffset-2.0f< GetMusicTime() && _start[_dummyCount] >= 0)
        {
            SpawnDummy(_dummyCount,0);
            SpawnDummy(_dummyCount, 1);
            _dummyCount++;
        }
         while (_end[_notesCount]+timeOffset - 2.0f < GetMusicTime() && _end[_notesCount] >= 0)
        {
            SpawnNotes(_notesCount,2);
            _notesCount++;

        }
    }
    void SpawnNotes(int num,int i)
    {
        Instantiate(notes[i], new Vector3(_posx2[num], _posy2[num], 0), Quaternion.identity);
    }

    void SpawnDummy(int num,int i)
    {
        Instantiate(notes[i], new Vector3(_posx1[num], _posy1[num], 0), Quaternion.identity);
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
                _posx1[i] = float.Parse(values[2]);
                _posy1[i] = float.Parse(values[3]);
                _posx2[i] = float.Parse(values[4]);
                _posy2[i] = float.Parse(values[5]);
                //_dummytiming[i] = _start[i] - 1.0f;

                _span[i] = _end[i] - _start[i];
            }
            i++;
        }
    }
    public float GetMusicTime()
    {
        return Time.time - _startTime-waitTime;
    }

    
}
