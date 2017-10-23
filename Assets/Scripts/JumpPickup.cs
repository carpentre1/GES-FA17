using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickup : MonoBehaviour {
	// Use this for initialization
	void Start () {
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
        yield return new WaitForSeconds(3);
        sprite.enabled = true;
        circle.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerMovement playermovement = collision.GetComponent<PlayerMovement>();
            playermovement.canDoubleJump = true;
            StartCoroutine(ToggleActive(3));
        }
    }
}
