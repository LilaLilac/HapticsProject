using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyNotes : MonoBehaviour
{
    GameController notesData;
    GameObject gameController;

    float endx;
    float endy;
    int noteCount = 0;

    float begin;
    float end;
    float span;

    Vector3 endposision;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        noteCount = notesData._dummyCount-1;
        if (noteCount != 0)
        {
            begin = notesData._start[noteCount];
            end = notesData._end[noteCount];
            
            endx = notesData._posx2[noteCount];
            endy = notesData._posy2[noteCount];
            Debug.Log("note3= " + noteCount);
        }
        else
        {
            begin = notesData._start[noteCount];
            end = notesData._end[noteCount];
            
            endx = notesData._posx2[noteCount];
            endy = notesData._posy2[noteCount];
            
        }
        

        

        span = end - begin;

        endposision = new Vector3(endx, endy, 0);
        Debug.Log("endpos= " + endposision);

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(1, 1, 1, 0);

        iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision, "time", 2.0f, "easeType", "linear", "delay", span));
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}