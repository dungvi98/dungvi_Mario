using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 3;
    [SerializeField] float force = 10;

    bool isDead = false;
    void Update()
    {
        if (isDead)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        Movement();
    }

    private void Movement()
    {
        var vel = rigid.velocity;
        vel.x = speed; 
        rigid.velocity = vel;
    }

    private void Jump()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            isDead = true;
            rigid.velocity = Vector2.zero;
            GameStateManager.CurrentState = GameState.GameOver;
        }
    }
}
