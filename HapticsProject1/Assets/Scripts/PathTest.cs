using UnityEngine;
using System.Collections;

public class PathTest : MonoBehaviour
{
    public int time = 100;
    public string PathName = "New Path 1";

    void Start()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "path", iTweenPath.GetPath(PathName),
            "time", time,
            "easeType", iTween.EaseType.linear,
            "orienttopath", true));
    }
}