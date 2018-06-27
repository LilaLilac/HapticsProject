using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] notes;
    //public GameObject pointer;
    public float[] _start;
    public float[] _end;
    public float[] _span;
    public float[] _posx; //座標
    public float[] _posy;
    //public int[] _direction; //なぞる向き
    //public int[] _SorE; //ノーツの始点あるいは終点
    //private float[] _dummytiming;

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
    //public static int[] finalResult;

    void Start()
    {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        _start = new float[1024];
        _end = new float[1024];
        _span = new float[1024];
        _posx = new float[1024];
        _posy = new float[1024];
        //_direction = new int[1024];
        //_SorE = new int[1024];
        LoadCSV();
        _startTime = Time.time;
        //_dummytiming = new float[1024];

        //Result = new int[5]; //great,good,bad,notes
        
    }

    void Update()
    {
        if (_isPlaying)
        {
            GameObject.Find("Timer").GetComponent<Text>().text = GetMusicTime().ToString("F2");
            CheckNextNotes();
            //scoreText.text = _score.ToString();

            if (Input.GetKeyDown(KeyCode.Space))　//押し始め判定
            {
                if (GetMusicTime() - _start[_begin]>=-0.1f && GetMusicTime() - _start[_begin]<= 0.1f)
                {
                    score += 100f;
              
                    GameObject.Find("Comment").GetComponent<Text>().text = "Great";
                    GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                    Instantiate(great, new Vector3(_posx[_begin],_posy[_begin],0),Quaternion.identity);

                    Great++ ;

                    _begin++;
                }
                else if (GetMusicTime() - _start[_begin] >= -0.15f && GetMusicTime() - _start[_begin] <= 0.15f)
                {
                    score += 50f;

                    GameObject.Find("Comment").GetComponent<Text>().text = "Good";
                    GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                    Instantiate(good, new Vector3(_posx[_begin], _posy[_begin], 0), Quaternion.identity);

                    Good++;

                    _begin++;
                }
                else if (GetMusicTime() - _start[_begin] >= -0.6f && GetMusicTime() - _start[_begin] <= 0.6f)
                {

                    GameObject.Find("Comment").GetComponent<Text>().text = "Bad";
                    GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                    Instantiate(bad, new Vector3(_posx[_begin], _posy[_begin], 0), Quaternion.identity);

                    Bad++;

                    _begin++;
                }
                else
                {

                }
                _isHold = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isHold)
                {
                    if (GetMusicTime() - _end[_release] >= -0.1f && GetMusicTime() - _end[_release] <= 0.1f)
                    {
                        score += 100f;

                        GameObject.Find("Comment").GetComponent<Text>().text = "Great";
                        GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");
                        //パスの終わりにエフェクトを入れたい　保持リストを作っていないので別途読み込み

                        Great++;

                        _release++;
                    }
                    else if (GetMusicTime() - _end[_release] >= -0.15f && GetMusicTime() - _end[_release] <= 0.15f)
                    {
                        score += 50f;

                        GameObject.Find("Comment").GetComponent<Text>().text = "Good";
                        GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");

                        Good ++ ;

                        _release++;
                    }
                    else if (GetMusicTime() - _end[_release] >= -0.6f && GetMusicTime() - _end[_release] <= 0.6f)
                    {

                        GameObject.Find("Comment").GetComponent<Text>().text = "Bad";
                        GameObject.Find("ScoreText").GetComponent<Text>().text = score.ToString("F0");

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
        startButton.SetActive(false);
        _startTime = Time.time;
        _audioSource.Play();
        _isPlaying = true;
        //Instantiate(pointer);
    }

    void CheckNextNotes()
    {
        while (_start[_dummyCount] + timeOffset-2.0f< GetMusicTime() && _start[_dummyCount] != 0)
        {
            /*if (_begin != _dummyCount&&_dummyCount!=0) //正しくカウントが進んでない（ミスした後）の調整　後日修正
            {
                _begin = _dummyCount;
            }*/
            SpawnDummy(_dummyCount,0);
            //Debug.Log("MusicTime = " + GetMusicTime());
            _dummyCount++;
        }
        while (_start[_notesCount] < GetMusicTime() && _start[_notesCount] != 0)
        {

            /*if (_release!= _notesCount&&_notesCount!=0)
            {
                _release = _notesCount;
            }*/
            SpawnDummy(_notesCount,1);
            //Debug.Log("MusicTime = "+GetMusicTime());
            _notesCount++;

        }
    }
    void SpawnNotes(int num)
    {
        int i;
        Vector3[] spawn= new Vector3[]{new Vector3(-10, 8, 0), new Vector3(-10, -8, 0), new Vector3(10, 8, 0), new Vector3(10, -8, 0) };
        i = num % 4;
        Instantiate(notes[num],
            spawn[i],
            Quaternion.identity);
    }

    void SpawnDummy(int num,int i)
    {
        Instantiate(notes[i], new Vector3(_posx[num], _posy[num], 0), Quaternion.identity);
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
                _posx[i] = float.Parse(values[2]);
                _posy[i] = float.Parse(values[3]);
                //_direction[i] = int.Parse(values[3]);
                //_SorE[i] = int.Parse(values[4]);
                //_dummytiming[i] = _start[i] - 1.0f;

                _span[i] = _end[i] - _start[i];
            }
            i++;
        }
    }
    public float GetMusicTime()
    {
        return Time.time - _startTime;
    }

    
}
