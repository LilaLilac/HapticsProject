using UnityEngine;
using System.Collections;

public class PointerController : MonoBehaviour
{
    private int time = 100;
    
    private string Paths;
    private int num=0;

    private float[] posx;
    private float[] posy;
    private float[] start;
    private float[] end;
    //private float[] span;
    

    GameController notesData;
    GameObject gameController;

    private float currentTime;

    void Start()
    {
        currentTime = 0;

        posx = new float[1024];
        posy = new float[1024];
        start = new float[1024];
        end = new float[1024];
        //span = new float[1024];

        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        //num = notesData._dummyCount;
        posx = notesData._posx;
        posy = notesData._posy;
        start = notesData._start;
        end = notesData._end;
        //span = notesData._span;

        /*iTween.MoveTo(this.gameObject, iTween.Hash(
                "position",new Vector3(posx[0],posy[0],0),
                "time", start[0],
                "easeType", iTween.EaseType.linear,
                "orienttopath", false));*/

    }

    private void Update()
    {
        currentTime += Time.deltaTime;


        if (currentTime >= start[num])
        {
            Paths = "Path " + num;

            iTween.MoveTo(this.gameObject, iTween.Hash(
                "path", iTweenPath.GetPath(Paths),
                "time", time,
                "easeType", iTween.EaseType.linear,
                "orienttopath", false));
            /*iTween.MoveTo(this.gameObject, iTween.Hash(
                "position", new Vector3(posx[num+1], posy[num+1], 0),
                "time", end[num+1]-start[num],
                "easeType", iTween.EaseType.linear,
                "orienttopath", false));*/
            num++;
        }
    }
}