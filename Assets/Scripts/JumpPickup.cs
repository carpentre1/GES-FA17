using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickup : MonoBehaviour {
    private PlayerMovement playermovement;
	// Use this for initialization
	void Start () {
        playermovement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ToggleActive(int duration)
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        CircleCollider2D circle = gameObject.GetComponent<CircleCollider2D>();
        sprite.enabled = false;
        circle.enabled = false;
        Debug.Log("inactive");
        yield return new WaitForSeconds(3);
        sprite.enabled = true;
        circle.enabled = true;
        Debug.Log("active");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.name == "Player")
        {
            PlayerMovement playermovement = collision.GetComponent<PlayerMovement>();
            playermovement.canDoubleJump = true;
            StartCoroutine(ToggleActive(3));
        }
    }
}
