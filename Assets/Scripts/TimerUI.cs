using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour {

    public Text txt;

    public static int currentLevel = 0;

	// Use this for initialization
	void Start () {
        if(this.name == "DeathCounter" || this.name == "DeathDisplay") {
            currentLevel++;
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            Debug.Log("level is " + sceneName + ", currentLevel is " + currentLevel);
        }
    }

    public void NextLevel()
    {
    }

    public void UpdateDeaths(int level)
    {
        if (this.name == "DeathCounter")
        {
            Debug.Log("updating");
            PlayerMovement.deaths++;
            switch (level)
            {
                case 1:
                    PlayerMovement.deaths_level1++;
                    txt.text = PlayerMovement.deaths_level1.ToString();
                    break;
                case 2:
                    PlayerMovement.deaths_level2++;
                    txt.text = PlayerMovement.deaths_level2.ToString();
                    break;
                case 3:
                    PlayerMovement.deaths_level3++;
                    txt.text = PlayerMovement.deaths_level3.ToString();
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		if(this.name == "TimerCounter")
        {
            PlayerMovement.timer += Time.deltaTime;
            txt.text = PlayerMovement.timer.ToString("F2");
        }
	}

    void UpdateFinalBoards()
    {
        if (this.name == "TimeDisplay")
        {
            float totalTime = PlayerMovement.timer_level1 + PlayerMovement.timer_level2 + PlayerMovement.timer_level3;
            txt.text = "Level 1 time: " + PlayerMovement.timer_level1.ToString() +
                "\nLevel 2 time: " + PlayerMovement.timer_level2.ToString() +
                "\nLevel 3 time: " + PlayerMovement.timer_level3.ToString() +
                "\nOverall time: " + totalTime.ToString();
        }
        if (this.name == "DeathDisplay")
        {
            txt.text = "Level 1 deaths: " + PlayerMovement.deaths_level1.ToString() +
                "\nLevel 2 deaths: " + PlayerMovement.deaths_level2.ToString() +
                "\nLevel 3 deaths: " + PlayerMovement.deaths_level3.ToString() +
                "\nOverall deaths: " + PlayerMovement.deaths.ToString();
        }
    }
}
