using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtasGuide : MonoBehaviour
{
    GameController notesData;
    GameObject gameController;

    float endx;
    float endy;
    int noteCount = 0;

    float begin;
    float end;
    float span;

    public string PathName = "New Path 1";
    private string Paths;

    Vector3 endposision;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        noteCount = notesData._mainCount - 1;
        if (noteCount != 0)
        {
            begin = notesData._start[noteCount];
            end = notesData._end[noteCount];

            endx = notesData._posx2[noteCount];
            endy = notesData._posy2[noteCount];

        }
        else
        {
            begin = notesData._start[noteCount];
            end = notesData._end[noteCount];

            endx = notesData._posx2[noteCount];
            endy = notesData._posy2[noteCount];

        }




        span = end - begin;
        

        //endposision = new Vector3(endx, endy, 0);


        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(1, 1, 1, 0);

        Paths = "Path " + noteCount;

        iTween.MoveTo(this.gameObject, iTween.Hash(
            "path", iTweenPath.GetPath(Paths),
            "time", span,
            "easeType", iTween.EaseType.linear,
            "orienttopath", false));
    }

    // Update is called once per frame
    void Update()
    {

    }


}