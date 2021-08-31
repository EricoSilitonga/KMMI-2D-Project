﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform transform;
    private float moveDir;
    [SerializeField]
    private Animator anim;
    private bool isRunning,isIdle;
    private bool isFaceLeft = false;
    public LayerMask whatIsGround;
    public int score;
    public UI ui;
    private bool isJump = false;
    private void Start()
    {
        score = 0;
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void CheckAnimation()
    {
        anim.SetBool("Jump", isJump);
        anim.SetBool("Running", isRunning);
        anim.SetBool("Idle", isIdle);
    }

    private void Update()
    {
        
        moveDir = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        
        if (Mathf.Abs(rb.velocity.x)>= 0.01f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        //Menghitung arah hadap
        if(moveDir > 0 && isFaceLeft)
        {
            Flip();
        }else if(moveDir < 0 && !isFaceLeft)
        {
            Flip();
        }

        //idle Checker
        if(moveDir == 0)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }
        rb.velocity = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
        if (CrossPlatformInputManager.GetButtonDown("Jump") && IsGrounded())
        {
            AudioManager.instance.PlaySFX(0);
            isJump = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        CheckAnimation();
    }



    bool IsGrounded()
    {
       
        return Physics2D.Raycast(transform.position, Vector2.down, 2f,whatIsGround);
    }

    void Flip()
    {
        isFaceLeft = !isFaceLeft;
        transform.Rotate(0.0f, 180f, 0f);
    }

    public void GameOver()
    {
        AudioManager.instance.PlaySFX(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int value)
    {
        score+=value;
        ui.SetScoreText(score);
        AudioManager.instance.PlaySFX(1);
    }

    public void OnShowAdButton()
    {
        AddScore(50);
        AdManager.instance.PlayAd();
    }
}
