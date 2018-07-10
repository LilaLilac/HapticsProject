using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideNote : MonoBehaviour {

    float span=2.0f;

    int noteCount = 0;

    float alfa;
    float remain;

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        remain = span;
        sprite = GetComponent<SpriteRenderer>();
        sprite.material.color=new Color(1, 1, 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
        remain -= Time.deltaTime;
        alfa = remain / span;
        sprite.material.color = new Color(1, 1, 1, 1-alfa);
        gameObject.transform.localScale = new Vector3(alfa*0.5f,alfa*0.5f,0);
        if (remain < 0)
        {
            Destroy(gameObject);
        }
    }
}
