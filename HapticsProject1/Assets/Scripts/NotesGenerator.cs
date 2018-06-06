using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour {

    public GameObject notes;
    float delta = 0;
    float notetime = 0;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if (this.delta > this.notetime)
        {
            
        }
	}
}
