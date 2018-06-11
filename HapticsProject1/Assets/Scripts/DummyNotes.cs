using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyNotes : MonoBehaviour
{
    GameController notesData;
    GameObject gameController;
    int posisionx;
    int posisiony;
    int noteCount = 0;
    int direction;
    Vector3 endposision;
    Vector3[] slidepos = new Vector3[] {
        new Vector3(1,1,0), //右上
        new Vector3(-1,1,0), //左上
        new Vector3(1,0,0), //右
        new Vector3(0,1,0) //上
    };
    //public float speed = 0;

    public float fadeTime = 2.0f;

    private float currentRemainTime;


    // Use this for initialization
    void Start()
    {
        currentRemainTime = fadeTime;
        

        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        noteCount = notesData._notesCount-1; 
        posisionx = notesData._posx[noteCount];
        posisiony = notesData._posy[noteCount];
        direction = notesData._direction[noteCount];
        endposision = new Vector3(posisionx, posisiony, 0);
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        currentRemainTime -= Time.deltaTime;
        if (currentRemainTime > 0)
        {
            float newAlpha = 1 - currentRemainTime / fadeTime;
            sprite.material.color = new Color(1, 1, 1, newAlpha);
        }
        
        if (currentRemainTime < 0)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision + slidepos[direction], "time", 2.0f, "easeType", "linear", "delay", 1.0f));
        }
    }


}