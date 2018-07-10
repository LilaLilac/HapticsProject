using UnityEngine;
using System.Collections;

public class DummyPath : MonoBehaviour
{
    public int time = 100;
    public string PathName = "New Path 1";
    private string Paths;
    private int num;

    GameController notesData;
    GameObject gameController;

    private float span;

    //public float fadeTime = 0.5f;
    //private float currentRemainTime;

    void Start()
    {
        //currentRemainTime = fadeTime;

        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        num = notesData._mainCount-1;

        span = notesData._end[num] - notesData._start[num];

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(1, 1, 1, 0);

        Paths = "Path "+num;
        //Debug.Log("span " + num + " = " + span);
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "path", iTweenPath.GetPath(Paths),
            "time", span,
            "easeType", iTween.EaseType.linear,
            "orienttopath", false));
        
    }

    private void Update()
    {
        //SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        /*currentRemainTime -= Time.deltaTime;
        if (currentRemainTime > 0)
        {
            float newAlpha = currentRemainTime / fadeTime;
            sprite.material.color = new Color(1, 1, 1, newAlpha);
        }

        if (currentRemainTime < 0)
        {
            //Destroy(gameObject);
        }*/
    }
}