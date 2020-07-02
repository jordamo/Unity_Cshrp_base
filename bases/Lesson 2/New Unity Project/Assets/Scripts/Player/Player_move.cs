using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_move : MonoBehaviour
{
    [Serializable]
    private Vector2 speed = new Vector2(5, 2);

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        var colider = GetComponent<BoxCollider2D>();
        Vector3 cur = new Vector3();
        cur.x = Input.GetAxis("Horizontal") * speed.x;
        // Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.Space))
            cur.y = speed.y;
        
            colider.transform.position += cur;
    }
}
