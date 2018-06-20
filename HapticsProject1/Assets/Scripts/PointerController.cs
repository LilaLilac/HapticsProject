using UnityEngine;
using System.Collections;

public class PointerController : MonoBehaviour
{
    //private int time = 100;
    private int i = 0;
    
    private string Paths;
    private int num=0;

    private float[] posx;
    private float[] posy;
    private float[] start;
    private float[] end;
    //private float[] span;

    private float[] spanList;
    private float[] timeList;    

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

        timeList = new float[1024];
        spanList = new float[1024];

        gameController = GameObject.Find("GameController");
        notesData = gameController.GetComponent<GameController>();
        //num = notesData._dummyCount;
        posx = notesData._posx;
        posy = notesData._posy;
        start = notesData._start;
        end = notesData._end;

        spanList[0] = start[0];
        timeList[0] = 0;

        while (start[i] != 0f)
        {
            spanList[2 * i + 1] = end[i] - start[i];
            spanList[2 * (i + 1)] = start[i+ 1] - end[i];
            timeList[2 * i + 1] = start[i];
            timeList[2 * (i + 1)] = end[i];
            i++;
        }

        //span = notesData._span;

        /*iTween.MoveTo(this.gameObject, iTween.Hash(
                "position",new Vector3(posx[0],posy[0],0),
                "time", start[0],
                "easeType", iTween.EaseType.linear,
                "orienttopath", false));*/

    }

    public void MoveNext(int i)
    {
        Debug.Log(timeList[i]);
        Debug.Log(i);
        if (i % 2 == 0)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash(
                "position", new Vector3(posx[i/2], posy[i/2], 0),
                "time", spanList[i/2],
                "easeType", iTween.EaseType.linear,
                "orienttopath", false));
        }
        else
        {
            Paths = "Path " + i/2;

            iTween.MoveTo(this.gameObject, iTween.Hash(
                "path", iTweenPath.GetPath(Paths),
                "time", spanList[i/2],
                "easeType", iTween.EaseType.linear,
                "orienttopath", false));
        }
    }

    private void Update()
    {
        //currentTime += Time.deltaTime;
        
        if (notesData.GetMusicTime() > timeList[num]+notesData.timeOffset)
        {
            Debug.Log("pointerTime = " + currentTime);
            MoveNext(num);
            num++;            
        }
        
    }
}