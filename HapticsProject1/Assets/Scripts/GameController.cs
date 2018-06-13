using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] notes;
    private float[] _timing;
    public float[] _posx; //座標
    public float[] _posy;
    //public int[] _direction; //なぞる向き
    //public int[] _SorE; //ノーツの始点あるいは終点

    public string filePass;
    public int _notesCount = 0;

    private AudioSource _audioSource;
    private float _startTime = 0;

    public float timeOffset = -1;

    private bool _isPlaying = false;
    public GameObject startButton;


    void Start()
    {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        _timing = new float[1024];
        _posx = new float[1024];
        _posy = new float[1024];
        //_direction = new int[1024];
        //_SorE = new int[1024];
        LoadCSV();
        _startTime = Time.time;
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
        while (_timing[_notesCount] + timeOffset < GetMusicTime()-3.0f && _timing[_notesCount] != 0)
        {
            //SpawnNotes(UnityEngine.Random.Range(0, 5));
            SpawnDummy(_notesCount,0);
            //_notesCount++;
        }
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0)
        {
            SpawnDummy(_notesCount,1);
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
                _timing[i] = float.Parse(values[0]);
                _posx[i] = float.Parse(values[1]);
                _posy[i] = float.Parse(values[2]);
                //_direction[i] = int.Parse(values[3]);
                //_SorE[i] = int.Parse(values[4]);
            }
            i++;
        }
    }
    float GetMusicTime()
    {
        return Time.time - _startTime;
    }
}
