using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideNote2 : MonoBehaviour {

    float span=3.0f;

    int noteCount = 0;

    float alfa;
    float remain;

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        remain = span;
        sprite = GetComponent<SpriteRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {
        remain -= Time.deltaTime;
        alfa = remain / span;
        sprite.material.color = new Color(1, 0.3f,0.3f, 1-alfa);
        gameObject.transform.localScale = new Vector3(alfa*0.5f,alfa*0.5f,0);
        if (remain < 0)
        {
            Destroy(gameObject);
        }
    }
}
