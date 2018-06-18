using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    public float fadeTime = 0.5f; //フェードに掛けたい時間
    private float currentRemainTime;

    void Start()
    {
        currentRemainTime = fadeTime;
    }

    void Update()
    {   
        
        SpriteRenderer sprite = GetComponent<SpriteRenderer>(); //使いたいオブジェクトにこのままアタッチ
        currentRemainTime -= Time.deltaTime;
        if(currentRemainTime > 0)
        {
            float newAlpha = 1 - currentRemainTime / fadeTime; //フェードイン
            sprite.material.color = new Color(1, 1, 1, newAlpha); //最後のパラメータが透明度　0で透明、1で不透明
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}

