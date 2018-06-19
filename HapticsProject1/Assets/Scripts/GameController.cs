using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] notes;
    private float[] _start;
    private float[] _end;
    public float[] _span;
    public float[] _posx; //座標
    public float[] _posy;
    //public int[] _direction; //なぞる向き
    //public int[] _SorE; //ノーツの始点あるいは終点
    //private float[] _dummytiming;

    public string filePass;
    public int _notesCount = 0;
    public int _dummyCount = 0;

    private AudioSource _audioSource;
    private float _startTime = 0;


    public float timeOffset = -1;

    private bool _isPlaying = false;
    public GameObject startButton;


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
    }

    void Update()
    {
        if (_isPlaying)
        {
            CheckNextNotes();
            //scoreText.text = _score.ToString();
        }
         //scoreText.text = _score.ToString();
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        _startTime = Time.time;
        _audioSource.Play();
        _isPlaying = true;
    }

    void CheckNextNotes()
    {
        while (_start[_dummyCount] + timeOffset-2.0f< GetMusicTime() && _start[_dummyCount] != 0)
        {
            //SpawnNotes(UnityEngine.Random.Range(0, 5));
            SpawnDummy(_dummyCount,0);
            _dummyCount++;
        }
        while (_start[_notesCount] + timeOffset< GetMusicTime() && _start[_notesCount] != 0)
        {
            //SpawnDummy(_notesCount, 0);
            SpawnDummy(_notesCount,1);
            //Debug.Log("_notesCount="+_notesCount);
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
    float GetMusicTime()
    {
        return Time.time - _startTime;
    }
}
