using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour {
    GameController notesData;
    GameObject gameController;
    int posisionx;
    int posisiony;
    int noteCount;
    int direction;
    Vector3 endposision;
    Vector3[] slidepos=new Vector3[] {
        new Vector3(1,1,0), //右上
        new Vector3(-1,1,0), //左上
        new Vector3(1,0,0), //右
        new Vector3(0,1,0) //上
    };
    //public float speed = 0;
    
    
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        noteCount = notesData._notesCount;
        //noteCount = gameController._notesCount;
        posisionx = notesData._posx[noteCount];
        posisiony = notesData._posy[noteCount];
        direction = notesData._direction[noteCount];
        endposision = new Vector3(posisionx, posisiony, 0);

        //speed*= 0.1f;
        //this.transform.Translate(-this.speed, 0, 0);
        iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision, "time", 3.0f, "easeType", "linear","delay", 1.0f));

        iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision+slidepos[direction], "time", 0.5f, "easeType", "linear"));
    }

    // Update is called once per frame
    void Update () {
        
    }
    

}
