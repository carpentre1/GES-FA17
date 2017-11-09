using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour {

    public Text txt;

    public static int currentLevel = 0;

    //grades for time completion
    //extremely good times: 5, 20, 41
    static float gradeS = 75;
    static float gradeA = 100;
    static float gradeB = 150;
    static float gradeC = 200;

    static string gradeS_text = "S\nfastest boi in the west";
    static string gradeA_text = "A\nreally fast boi";
    static string gradeB_text = "B\npretty fast boi";
    static string gradeC_text = "C\nnot a slow boi";

    // Use this for initialization
    void Start () {
        if(this.name == "TimeDisplay" || this.name == "DeathDisplay" || this.name == "GradeDisplay")
        {
            UpdateFinalBoards();
        }
    }

    public int GetLevel()//checks level names to determine level and return it as an int
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        switch (sceneName)
        {
            case "Title":
                currentLevel = 0;
                return 0;
            case "level1":
                currentLevel = 1;
                return 1;
            case "level2":
                currentLevel = 2;
                return 2;
            case "level3":
                currentLevel = 3;
                return 3;
            case "Finish":
                currentLevel = 4;
                return 4;
            default:
                return 0;
        }
    }

    public void UpdateDeaths(int level)
    {
        if (this.name == "DeathCounter")
        {
            Debug.Log("updating");
            PlayerMovement.deaths++;
            switch (GetLevel())
            {
                case 1:
                    PlayerMovement.deaths_level1++;
                    txt.text = "Deaths: " + PlayerMovement.deaths_level1.ToString();
                    break;
                case 2:
                    PlayerMovement.deaths_level2++;
                    txt.text = "Deaths: " + PlayerMovement.deaths_level2.ToString();
                    break;
                case 3:
                    PlayerMovement.deaths_level3++;
                    txt.text = "Deaths: " + PlayerMovement.deaths_level3.ToString();
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
            txt.text = "Time: " + PlayerMovement.timer.ToString("F2");
        }
	}

    void UpdateFinalBoards()
    {
        Debug.Log("updating final boards");
        float totalTime = PlayerMovement.timer_level1 + PlayerMovement.timer_level2 + PlayerMovement.timer_level3;
        if (this.name == "TimeDisplay")
        {
            txt.text = "Level 1 time: " + PlayerMovement.timer_level1.ToString("F2") +
                "\nLevel 2 time: " + PlayerMovement.timer_level2.ToString("F2") +
                "\nLevel 3 time: " + PlayerMovement.timer_level3.ToString("F2") +
                "\n\nOVERALL TIME: " + totalTime.ToString("F2");
        }
        if (this.name == "DeathDisplay")
        {
            txt.text = "Level 1 deaths: " + PlayerMovement.deaths_level1.ToString() +
                "\nLevel 2 deaths: " + PlayerMovement.deaths_level2.ToString() +
                "\nLevel 3 deaths: " + PlayerMovement.deaths_level3.ToString() +
                "\n\nOVERALL DEATHS: " + PlayerMovement.deaths.ToString();
        }
        if (this.name == "GradeDisplay")
        {
            if(totalTime < gradeS)
            {
                txt.text = "Grade: " + gradeS_text;
            }
            else if (totalTime < gradeA)
            {
                txt.text = "Grade: " + gradeA_text;
            }
            else if (totalTime < gradeB)
            {
                txt.text = "Grade: " + gradeB_text;
            }
            else if (totalTime < gradeC)
            {
                txt.text = "Grade: " + gradeC_text;
            }
        }
    }
}
