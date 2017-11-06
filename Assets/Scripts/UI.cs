using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public PlayerMovement playermovement;

	// Use this for initialization
	void Start () {
		
	}
	public void UpdateDeaths(int level)
    {
        if(this.name == "DeathCounter")
        {
            PlayerMovement.deaths++;
            switch(level)
            {
                case 1:
                    PlayerMovement.deaths_level1++;
                    break;
                case 2:
                    PlayerMovement.deaths_level2++;
                    break;
                case 3:
                    PlayerMovement.deaths_level3++;
                    break;
                default:
                    break;
            }
        }
    }
	// Update is called once per frame
	void Update () {

	}
}
