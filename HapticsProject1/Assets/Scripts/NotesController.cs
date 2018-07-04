using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour {
    GameController notesData;
    GameObject gameController;
    float posisionx;
    float posisiony;
    int noteCount=0;
    
    Vector3 endposision;
    /*Vector3[] slidepos=new Vector3[] {
        new Vector3(1,1,0), //右上
        new Vector3(-1,1,0), //左上
        new Vector3(1,0,0), //右
        new Vector3(0,1,0) //上
    };*/
    //public float speed = 0;

    


    // Use this for initialization
    void Start () {
      

        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        noteCount = notesData._notesCount-1; //なぜかずれたので補正　後で直しておきたい
        //noteCount = gameController._notesCount;
        posisionx = notesData._posx1[noteCount];
        posisiony = notesData._posy1[noteCount];
       
        endposision = new Vector3(posisionx, posisiony, 0);

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(1, 1, 1,0);
    }

    // Update is called once per frame
    void Update () {
   
    }
    

}
