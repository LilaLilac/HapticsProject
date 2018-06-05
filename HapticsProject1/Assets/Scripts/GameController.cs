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
    //private int[] _direction; //なぞる向き

    public string filePass;
    public int _notesCount = 0;

    //private AudioSource _audioSource;
    private float _startTime = 0;

    public float timeOffset = -1;


    void Start()
    {
        _timing = new float[1024];
        _posx = new int[1024];
        _posy = new int[1024];
        //_direction = new int[1024];
        LoadCSV();
        _startTime = Time.time;
    }

    void Update()
    {
         CheckNextNotes();
         //scoreText.text = _score.ToString();
    }

    void CheckNextNotes()
    {
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0)
        {
            SpawnNotes(UnityEngine.Random.Range(0, 5));
            _notesCount++;
        }
    }
    void SpawnNotes(int num)
    {
        Instantiate(notes[num],
            new Vector3(-4.0f + (2.0f * num), 10.0f, 0),
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
                _posy[i] = int.Parse(values[1]);
                //_direction[i] = int.Parse(values[2]);
            }
            i++;
        }
    }
    float GetMusicTime()
    {
        return Time.time - _startTime;
    }
}
