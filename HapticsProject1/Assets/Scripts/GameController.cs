using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] notes;
    private float[] _timing;
    public int[] _posx; //座標
    public int[] _posy;
    public int[] _direction; //なぞる向き

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
        _posx = new int[1024];
        _posy = new int[1024];
        _direction = new int[1024];
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
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0)
        {
            //SpawnNotes(UnityEngine.Random.Range(0, 5));
            SpawnNotes(_direction[_notesCount]);
            Debug.Log(_direction[_notesCount]);
            Debug.Log("_notesCount "+_notesCount);
            _notesCount++;
        }
    }
    void SpawnNotes(int num)
    {
        int i;
        Vector3[] spawn= new Vector3[]{new Vector3(-10, 8, 0), new Vector3(-10, -8, 0), new Vector3(10, 8, 0), new Vector3(10, -8, 0) };
        i = UnityEngine.Random.Range(0,4);
        Instantiate(notes[num],
            spawn[i],
            Quaternion.identity);
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
                _posx[i] = int.Parse(values[1]);
                _posy[i] = int.Parse(values[2]);
                _direction[i] = int.Parse(values[3]);
            }
            i++;
        }
    }
    float GetMusicTime()
    {
        return Time.time - _startTime;
    }
}
