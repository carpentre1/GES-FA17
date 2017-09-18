using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 4f;

    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        //transform.position = new Vector3(1, 1, 1);
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(KeyCode.D)) 
        //{
        //    transform.Translate(new Vector3(0.2f, 0, 0));
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(new Vector3(-0.2f, 0, 0));
        //}
        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(0, 5, 0);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(0.1f * horizontalInput, 0, 0);
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
    }
}
