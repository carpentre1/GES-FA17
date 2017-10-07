using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 4f;

    [SerializeField]
    float jumpStrength = 5f;

    [SerializeField]
    Transform groundDetectPoint;

    [SerializeField]
    float groundDetectRadius = .2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    private bool isOnGround;
    bool facingRight = true;

    Rigidbody2D rb;
    Animator an;
    void Start () {
        //transform.position = new Vector3(1, 1, 1);
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();

    }
	
	void Update ()
    {
        UpdateIsOnGround();
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

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        an.SetFloat("Speed", Mathf.Abs(horizontalInput));
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        if(horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if(horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }
}
