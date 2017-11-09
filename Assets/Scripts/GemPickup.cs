using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour {
    public GemUpdate gemupdate;

	// Use this for initialization
    //could use a static variable here to track number of gems collected, since that would belong to the
    //script as a whole instead of each individual gameobject with that script
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerMovement playermovement = collision.GetComponent<PlayerMovement>();
            playermovement.coins += 1;
            PlayerMovement.timer -= 5;
            gameObject.SetActive(false); //if restarting a level is added later, will need to reactivate the gems
            gemupdate.GemGained();

        }
    }
}
