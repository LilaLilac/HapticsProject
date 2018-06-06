using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour {
    GameController notesData;
    GameObject gameController;
    int posisionx;
    int posisiony;
    int noteCount;
    Vector3 endposision;
    //public float speed = 0;
    
    
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        noteCount = notesData._notesCount;
        //noteCount = gameController._notesCount;
        posisionx = notesData._posx[noteCount];
        posisiony = notesData._posy[noteCount];
        endposision = new Vector3(posisionx, posisiony, 0);

        //speed*= 0.1f;
        //this.transform.Translate(-this.speed, 0, 0);
        iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision, "time", 2f, "easeType", "linear","delay", 1.0f));

        //iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision+new Vector3(-1, -1, 0), "time", 0.5f, "easeType", "linear"));
    }

    // Update is called once per frame
    void Update () {
        
    }
    

}
