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
        Vector3 p_cam = transform.position;
        Vector3 p_plr = target.transform.position;
        if (p_cam.x - WH.x >= p_plr.x)
        {
            transform.position = new Vector3(p_cam.x + (p_plr.x - (p_cam.x - WH.x)), p_cam.y, p_cam.z);
        }
        else if (p_cam.x + WH.x <= p_plr.x)
        {
            transform.position = new Vector3(p_cam.x + (p_plr.x - (p_cam.x + WH.x)),p_cam.y,p_cam.z);
        }
        
        if (p_cam.y - WH.y/4 >= p_plr.y)
        {
            transform.position = new Vector3(transform.position.x, p_cam.y + (p_plr.y - (p_cam.y - WH.y/4)), p_cam.z);
        }
        else if (p_cam.y + WH.y <= p_plr.y)
        {
            transform.position = new Vector3(transform.position.x,p_cam.y + (p_plr.y - (p_cam.y + WH.y)), p_cam.z);
        }
    }
}
