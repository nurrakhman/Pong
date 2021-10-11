﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Control Button
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;

    // Move Speed
    public float speed = 10.0f;

    // Boundary Move
    public float yBoundary = 9.0f;

    // RigidBody Racket
    private Rigidbody2D rigidBody2D;

    // Score
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity;
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0.0f;
        }

        rigidBody2D.velocity = velocity;

        Vector3 position = transform.position;
        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        }else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        transform.position = position;

    }

    public void IncrementScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int Score
    {
        get { return score; }
    }
}
