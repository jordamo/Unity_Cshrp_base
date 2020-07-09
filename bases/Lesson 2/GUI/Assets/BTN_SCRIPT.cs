using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.UIElements;

public class BTN_SCRIPT : MonoBehaviour
{
    public void CoolorChange()
    {
        Debug.Log("Shalom text");
        
    }
    public void CoolorChange2(TextMeshProUGUI target)
    {
        Debug.Log("Shalom text");
        Debug.Log($"{target}");
        target.color = Color.green;
    }

}
