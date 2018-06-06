using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{ public float now = 0f;
    public float start = 1.0f;
    public float end = 5.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        now += Time.deltaTime;
        //Debug.Log(now);
        if(now >= start && now <= end)
        {
            ScoreI();
        }
        else
        {
            ScoreD();
        }
    }
    void ScoreI()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Good");
        }
        else
        {
            Debug.Log("Bad");
        }
    }
    void ScoreD()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Bad");
        }
        else
        {
            Debug.Log("Newtral");
        }
    }

}
