using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemUpdate : MonoBehaviour {
    public PlayerMovement playermovement;
    //Image[] images;
    public Sprite hud_0;
    public Sprite hud_1;
    public Sprite hud_2;
    public Sprite hud_3;
    public Sprite hud_4;

    public Image imageLinker;

    // Use this for initialization
    void Start () {
        //GameObject thePlayer = GameObject.Find("Player");
        //PlayerMovement playermovement = thePlayer.GetComponent<PlayerMovement>();
        imageLinker = gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GemGained()
    {
        //Sprite chosenHud;
        //foreach (Sprite a in )
        switch (playermovement.coins)
        {

            case 0:
                imageLinker.sprite = hud_0;
                break;
            case 1:
                imageLinker.sprite = hud_1;
                break;
            case 2:
                imageLinker.sprite = hud_2;
                break;
            case 3:
                imageLinker.sprite = hud_3;
                break;
            case 4:
                imageLinker.sprite = hud_4;
                break;
            default:
                break;
        }
    }
}
