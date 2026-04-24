using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatcherMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float x;
    private Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float x = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed)
                x = -1f;
            else if (Keyboard.current.rightArrowKey.isPressed)
                x = 1f;
        }

        move = new Vector2(x * speed, rb.linearVelocity.y);

        rb.linearVelocity = move;
    }
}