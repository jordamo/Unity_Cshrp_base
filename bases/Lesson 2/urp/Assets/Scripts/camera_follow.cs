using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector2 WH;

    private void FixedUpdate()
    {
        if (transform.position.x - WH.x >= target.transform.position.x)
        {
            transform.position = new Vector3(target.transform.position.x - (transform.position.x - WH.x), 0f, transform.position.z);
        }
        else if (transform.position.x + WH.x <= target.transform.position.x)
        {
            transform.position = new Vector3(target.transform.position.x - (transform.position.x + WH.x),0f,transform.position.z);
        }
        
        if (transform.position.y - WH.y >= target.transform.position.y)
        {
            transform.position = new Vector3(0f, target.transform.position.y - (transform.position.y - WH.y),transform.position.z);
        }
        else if (transform.position.y + WH.y <= target.transform.position.y)
        {
            transform.position = new Vector3(0f,target.transform.position.y - (transform.position.y + WH.y),transform.position.z);
        }
    }
}
