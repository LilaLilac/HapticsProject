using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour {

    //public float speed = 0;
    Vector3 endposision =new Vector3(-3, 3, 0);
    
	// Use this for initialization
	void Start () {
        //speed*= 0.1f;
        //this.transform.Translate(-this.speed, 0, 0);
        iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision, "time", 2, "easeType", "linear","delay", 1.0f));

        iTween.MoveTo(this.gameObject, iTween.Hash("position", endposision+new Vector3(-1, -1, 0), "time", 0.5, "easeType", "linear"));
    }

    // Update is called once per frame
    void Update () {
        
    }
    

}
