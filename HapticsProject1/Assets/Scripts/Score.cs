using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
   
    private int start = 2;
    private int end = 3;
    
    
    void Update()
    {
       
        if (Timer.countTime <= start && timer <= end)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //ScoreDirectorに報告
                //GameObject director = GameObject.Find("ScoreDirector");
                //director.GetComponent<ScoreDirector>().IncreaseHp();
                //good effect
            }
            else
            {
                //ScoreDirectorに報告
                GameObject director = GameObject.Find("ScoreDirector");
                director.GetComponent<ScoreDirector>().DecreaseHp();
                //bad effect
            }
        }
    }
    
}
