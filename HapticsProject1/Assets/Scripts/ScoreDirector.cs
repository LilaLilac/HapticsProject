using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDirector : MonoBehaviour {
    GameObject gage;
    // Use this for initialization
    void Start () {
       this.gage = GameObject.Find("gage");
    }
	
	public void DecreaseHp() {
        this.gage.GetComponent<Image>().fillAmount *= 0.7f;
	}
}
