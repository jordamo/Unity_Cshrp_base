using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloom_script : MonoBehaviour
{
    private Material fadeMat;
    private bool isDissolving = true;
    private float fade = 0f;
    [SerializeField] private float scaleFactor = 2.5f;

    private void Start()
    {
        fadeMat = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fade = 0f;
            isDissolving = true;
        }
        
        if (isDissolving)
        {
            fade += Time.fixedDeltaTime*scaleFactor;
            if (fade >= 1f)
            {
                isDissolving = false;
                fade = 1f;
            }
            fadeMat.SetFloat("_Fade", fade);
        }
    }
}
