using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    static bool musicPlaying = false;

	// Use this for initialization
	void Start () {
        Debug.Log("ran");
        if (!musicPlaying)
        {
            musicPlaying = true;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("not destroying");
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
