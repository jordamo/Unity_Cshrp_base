using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MENU_BTN_SCRIPT2 : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string msg = "COUNT : ";
    private int count = 0;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = msg + count;

        if (Input.GetKey(KeyCode.Space))
            count++;
    }

    private void OnMouseDown()
    {
        // text.color = new Color(1f,0f,0f,1f);
        Debug.Log("HEEEE");
        text.fontSize = 200;
    }
}
