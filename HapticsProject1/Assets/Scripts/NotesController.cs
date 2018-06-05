using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour {

    public float speed = 0;


	// Use this for initialization
	void Start () {
        speed*= 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(-this.speed, 0, 0);
    }
}
