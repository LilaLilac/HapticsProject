using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

    GameController scoreData;
    GameObject gameController;

    public int[] result;
    public int great;
    public int good;
    public int bad;
    public int totalnotes=100;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);

        gameController = GameObject.Find("GameController");
        scoreData = gameController.GetComponent<GameController>();

       
    }
	
	// Update is called once per frame
	void Update () {
        great =scoreData.Great;
        good= scoreData.Good;
        bad = scoreData.Bad;
	}
}
