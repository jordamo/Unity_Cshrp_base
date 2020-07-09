using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MENU_BTN_SCRIPT : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int count = 0;
    private string msg = "Count:";
    private void FixedUpdate()
    {
        text.text = msg + " " + count;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
        }
    }
}
