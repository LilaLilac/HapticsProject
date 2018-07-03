using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyNotes : MonoBehaviour
{
    GameController notesData;
    GameObject gameController;
    float posisionx;
    float posisiony;
    float endx;
    float endy;
    int noteCount = 0;
    
    Vector3 endposision;
    Vector3 startpos;


    // Use this for initialization
    void Start()
    {
        //currentRemainTime = fadeTime;
        

        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        noteCount = notesData._notesCount-1; 
        posisionx = notesData._posx1[noteCount];
        posisiony = notesData._posy1[noteCount];
        endx= notesData._posx2[noteCount];
        endy= notesData._posy2[noteCount];
        //direction = notesData._direction[noteCount];
        startpos = new Vector3(posisionx, posisiony, 0);
        endposision = new Vector3(endx, endy, 0);

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(1, 1, 1, 0);

        iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision, "time", 2.0f, "easeType", "linear", "delay", 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        

        /*currentRemainTime -= Time.deltaTime;
        if (currentRemainTime > 0)
        {
            float newAlpha = 1 - currentRemainTime / fadeTime;
            sprite.material.color = new Color(1, 1, 1, newAlpha);
        }
        
        if (currentRemainTime < 0)
        {
            //iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision + slidepos[direction], "time", 2.0f, "easeType", "linear", "delay", 1.0f));
        }*/
    }


}