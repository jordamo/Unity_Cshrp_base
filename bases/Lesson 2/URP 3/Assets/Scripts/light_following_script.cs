using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_following_script : MonoBehaviour
{
    [SerializeField] private Transform p_target;
    [SerializeField] private float smooth_time = .05f;
    
    Vector2 tmp_Vec = Vector2.zero;
    Vector3 sub_vec = new Vector2(1f,.5f);
    
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, p_target.position + sub_vec, ref tmp_Vec, smooth_time);
    }
}
