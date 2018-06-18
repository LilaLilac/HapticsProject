using UnityEngine;
using System.Collections;

public class PathTest : MonoBehaviour
{
    public float time = 100;
    public string PathName = "New Path 1";
    private string Paths;
    private int num;

    GameController notesData;
    GameObject gameController;

    public float fadeTime = 2.0f;
    private float currentRemainTime;

    void Start()
    {
        currentRemainTime = fadeTime;

        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        num = notesData._notesCount-1;
        time = notesData._span[num];

        Paths = "Path "+num;

        iTween.MoveTo(this.gameObject, iTween.Hash(
            "path", iTweenPath.GetPath(Paths),
            "time", time,
            "easeType", iTween.EaseType.linear,
            "orienttopath", false));
        //Debug.Log("num=" + num);
    }

    private void Update()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        currentRemainTime -= Time.deltaTime;
        if (currentRemainTime > 0)
        {
            float newAlpha = currentRemainTime / fadeTime;
            sprite.material.color = new Color(1, 1, 1, newAlpha);
        }

        if (currentRemainTime < 0)
        {
            //Destroy(gameObject);
        }
    }
}