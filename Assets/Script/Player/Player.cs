using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour 
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    public float BaseSpeed { get; set; } = 5;
    public float SmoothTime { get; set; } = 0.04f;
    private Vector3 moveDir;
    private Vector3 velocitySmoothing;
    public FixedJoystick joystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }
    void movePlayer()
    {
        moveH = joystick.Horizontal;
        moveV = joystick.Vertical;
        moveDir = new Vector2(moveH, moveV);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, moveDir * BaseSpeed, ref velocitySmoothing, SmoothTime);
    }
}
