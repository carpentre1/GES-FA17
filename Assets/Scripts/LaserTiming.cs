using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTiming : MonoBehaviour {

    List<GameObject> lasers;
    float interval = 2;

    float redDelay = 0;
    float blueDelay = 1;
    float greenDelay = 2;
    float yellowDelay = 3;

    float redCurrent;
    float blueCurrent;
    float greenCurrent;
    float yellowCurrent;

    float redDuration = 2;
    float blueDuration = 2;
    float greenDuration = 5;
    float yellowDuration = 4;

    bool redActive = true;
    bool blueActive = true;
    bool greenActive = true;
    bool yellowActive = true;

    float current = 0;

	// Use this for initialization
	void Start () {
        //lasers = new List<GameObject>();
        //foreach (Transform child in transform)
        //{
        //    if (child.gameObject.name == "laserRedHorizontal" || child.gameObject.name == "Collision_RedLaser")
        //    {
                //lasers.Add(child.gameObject);
                //LaserTimer(child.gameObject, "red");
        //    }
        //}
        //Debug.Log(lasers);
        //foreach(GameObject L in lasers)
        //{
        //    L.SetActive(false);
        //    Debug.Log("set one inactive");
        //}
	}

    void LaserToggle(GameObject L)
    {
        if (L.activeSelf)
        {
            Debug.Log("deactivating");
            L.SetActive(false);
            StartCoroutine(LaserDelay(L, 1));
        }
        //else
        //{
        //    Debug.Log("reactivating");
        //    L.SetActive(true);
        //}
    }
    IEnumerator LaserDelay(GameObject L, float delay)
    {
        if (L.name == "laserRedHorizontal" || L.name == "laserRedVertical" || L.name == "Collision_RedLaser")
        {
            yield return new WaitForSeconds(delay*redDuration);
            L.SetActive(true);
            redActive = true;
        }
        if (L.name == "laserBlueHorizontal" || L.name == "laserBlueVertical" || L.name == "Collision_BlueLaser")
        {
            yield return new WaitForSeconds(delay * blueDuration);
            L.SetActive(true);
            blueActive = true;
        }
        if (L.name == "laserGreenHorizontal" || L.name == "laserGreenVertical" || L.name == "Collision_GreenLaser")
        {
            yield return new WaitForSeconds(delay * greenDuration);
            L.SetActive(true);
            greenActive = true;
        }
        if (L.name == "laserYellowHorizontal" || L.name == "laserYellowVertical" || L.name == "Collision_YellowLaser")
        {
            yield return new WaitForSeconds(delay * yellowDuration);
            L.SetActive(true);
            yellowActive = true;
        }
    }

    // Update is called once per frame
    void Update () 
    {
        Debug.Log(current);
        redCurrent += Time.deltaTime;
        blueCurrent += Time.deltaTime;
        greenCurrent += Time.deltaTime;
        yellowCurrent += Time.deltaTime;
        //time delay for each laser
        //every frame an update is called and checks for a laser to toggle activity on
        //red lasers
        if (redCurrent > redDelay + interval)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "laserRedHorizontal" || child.gameObject.name == "laserRedVertical" || child.gameObject.name == "Collision_RedLaser")
                {
                    if (redActive)
                        LaserToggle(child.gameObject);
                }
            }
            redActive = false;
            redCurrent = 0;
        }
        //blue lasers
        if (blueCurrent > blueDelay + interval)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "laserBlueHorizontal" || child.gameObject.name == "laserBlueVertical" || child.gameObject.name == "Collision_BlueLaser")
                {
                    if(blueActive)
                        LaserToggle(child.gameObject);
                }
            }
            blueActive = false;
            blueCurrent = 0;
        }
        //green lasers
        if (greenCurrent > greenDelay + interval)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "laserGreenHorizontal" || child.gameObject.name == "laserGreenVertical" || child.gameObject.name == "Collision_GreenLaser")
                {
                    if (greenActive)
                        LaserToggle(child.gameObject);
                }
            }
            greenActive = false;
            greenCurrent = 0;
        }
        //yellow lasers
        if (yellowCurrent > yellowDelay + interval)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "laserYellowHorizontal" || child.gameObject.name == "laserYellowVertical" || child.gameObject.name == "Collision_YellowLaser")
                {
                    if (yellowActive)
                    {
                        LaserToggle(child.gameObject);
                    }
                }
            }
            yellowActive = false;
            yellowCurrent = 0;
        }
    }
}
