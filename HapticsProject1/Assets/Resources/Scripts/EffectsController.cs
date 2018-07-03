using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour {

    public float remainTime=2f;

	// Use this for initialization
	void Start () {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(1, 1, 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
        remainTime -= Time.deltaTime;
        if (remainTime < 0f)
        {
            Destroy(gameObject);
        }
	}
}
