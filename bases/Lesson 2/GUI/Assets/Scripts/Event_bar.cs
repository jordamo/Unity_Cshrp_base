using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_bar : MonoBehaviour
{
    public void OnMouseEnter(float val)
    {
        Debug.Log($"value = {val}");
    }
}
