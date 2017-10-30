﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//in Tiled: unity:sortingLayerName        Ground / unity:tag unity:layer (physics layer)
public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 44f;

    [SerializeField]
    float jumpStrength = 55f;

    [SerializeField]
    Transform groundDetectPoint;

    [SerializeField]
    float groundDetectRadius = 1f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    [SerializeField]
    float maxYSpeed = 12f;

    bool isOnGround;
    bool facingRight = true;
    bool tryingToJump;
    bool dead = false;


    public bool canDoubleJump;
    public int coins = 0;

    public AudioClip jump;
    public AudioClip doublejump;
    public AudioClip checkpoint;
    public AudioClip finish;
    public AudioClip death;
    public AudioClip bounce;
    public AudioClip gempickup;
    public AudioClip coinpickup;

    private LevelManager levelManager;


    Vector3 spawnPoint;

    Rigidbody2D rb;
    Animator an;
    Animator an_torch;
    private float horizontalInput;

    void Start () {
        StartLevel();
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        

    }

    void StartLevel()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn").transform.position;
        transform.position = spawnPoint;
    }
	
	void Update ()//test for input here
    {
        GetMovementInput();
        GetJumpInput();
        UpdateIsOnGround();
        if(isOnGround)
        {
            canDoubleJump = true;
            an.SetBool("isOnGround", true);
        }
        else
        {
            an.SetBool("isOnGround", false);
        }
        //Jump();
        //Movement();
    }

    private void GetJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            tryingToJump = true;
        }
        else
        {
        //    tryingToJump = false;
        }
    }

    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()//do the physics operations here
    {
        Jump();
        Movement();
    }
    void UpdateIsOnGround()
    {
        Collider2D[] groundObjects = Physics2D.OverlapCircleAll(groundDetectPoint.position, groundDetectRadius, whatCountsAsGround);
        isOnGround = groundObjects.Length > 0;
    }
    void Flip()
    {
        if(dead)
        {
            return;
        }
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void PlayerDeath()
    {
        if(!dead)
        {
            //if(facingRight = !facingRight)
            //{
            //   Flip();
            //}
            dead = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            an.Play("Hurt");
            //AudioSource.PlayClipAtPoint(death, transform.position);
            Invoke("PlayerDeath", .6f);
        }
        else
        {
            an.Play("Idle");
            rb.constraints = RigidbodyConstraints2D.None;
            transform.position = spawnPoint;
            dead = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Collision_Death")
        {
            if (!dead)
            {
                PlayerDeath();
            }
        }
            if (collision.gameObject.name == "Collision_Bounce")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength * 1.5f);
            //AudioSource.PlayClipAtPoint(bounce, transform.position);
        }
        if (collision.gameObject.name == "Coin")
        {
            coins += 1;
            //AudioSource.PlayClipAtPoint(gempickup, transform.position);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "Jump_Refresh")
        {
            canDoubleJump = true;
            //AudioSource.PlayClipAtPoint(coinpickup, transform.position);
            collision.gameObject.SetActive(false);
            StartCoroutine(Wait());
            collision.gameObject.SetActive(true);
        }
            
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            an_torch = collision.gameObject.GetComponent<Animator>();
            //AudioSource.PlayClipAtPoint(checkpoint, transform.position);
            spawnPoint = transform.position;
            an_torch.SetBool("Lit", true);
        }
        if (collision.gameObject.tag == "Finish")
        {
            levelManager.FinishReached();
            //AudioSource.PlayClipAtPoint(finish, transform.position);
            //transform.position = spawnPoint;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void Jump()
    {
        if (tryingToJump && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            //AudioSource.PlayClipAtPoint(jump, transform.position);
            tryingToJump = false;
            an.SetBool("isOnGround", false);
        }
        else if (tryingToJump && !isOnGround && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            //AudioSource.PlayClipAtPoint(doublejump, transform.position);
            canDoubleJump = false;
            tryingToJump = false;
            an.SetBool("isOnGround", false);
        }
        else
        {
            tryingToJump = false;
        }
    }

    private void Movement()
    {
        an.SetFloat("Speed", Mathf.Abs(horizontalInput));
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > maxYSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Mathf.Sign(GetComponent<Rigidbody2D>().velocity.y) * maxYSpeed);
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if(horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }
}
