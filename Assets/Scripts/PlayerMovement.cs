using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private bool isOnGround;
    bool facingRight = true;
    bool canDoubleJump;
    bool tryingToJump;
    int coins = 0;

    Vector3 spawnPoint;

    Rigidbody2D rb;
    Animator an;
    private float horizontalInput;

    void Start () {
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn").transform.position;
        Debug.Log(spawnPoint);
        //transform.position = new Vector3(1, 1, 1);
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();

    }
	
	void Update ()//test for input here
    {
        GetMovementInput();
        GetJumpInput();
        UpdateIsOnGround();
        if(isOnGround)
        {
            canDoubleJump = true;
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
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Collision_Death")
        {
            transform.position = spawnPoint;
        }
        if (collision.gameObject.name == "Finish")
        {
            transform.position = spawnPoint;
        }
        if (collision.gameObject.name == "Checkpoint")
        {
            spawnPoint = collision.gameObject.transform.position;
        }
            if (collision.gameObject.name == "Collision_Bounce")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength * 1.5f);
        }
        if (collision.gameObject.name == "Coin")
        {
            coins += 1;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "Jump_Refresh")
        {
            canDoubleJump = true;
            collision.gameObject.SetActive(false);
            StartCoroutine(Wait());
            collision.gameObject.SetActive(true);
        }
            
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void Jump()
    {
        if (tryingToJump && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            tryingToJump = false;
        }
        else if (tryingToJump && !isOnGround && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            canDoubleJump = false;
            tryingToJump = false;
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
