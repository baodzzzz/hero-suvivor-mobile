using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour 
{
    public FixedJoystick joystick;
    private Rigidbody rb;
    private float moveH, moveV, speedMove = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }
    void movePlayer()
    {
        // moveH = Input.GetAxis("Horizontal");
        //moveV = Input.GetAxis("Vertical");
        moveH = joystick.Horizontal;
        moveV = joystick.Vertical;
        Vector3 dir = new Vector3(moveH, 0, moveV);
        rb.velocity = new Vector3(moveH * speedMove, rb.velocity.y, moveV*speedMove);
        if(dir != Vector3.zero)
        {
            transform.LookAt(transform.position + dir);
        }
    }
}
