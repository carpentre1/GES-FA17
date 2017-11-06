using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private int _activeSceneBuildIndex = 0;

    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        _activeSceneBuildIndex = activeScene.buildIndex;
    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
        if (name == "Start Menu") { /*reset*/ }
    }

    public void RestartGame(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
        PlayerMovement.deaths = 0; PlayerMovement.deaths_level1 = 0; PlayerMovement.deaths_level2 = 0; PlayerMovement.deaths_level3 = 0;
        PlayerMovement.timer = 0; PlayerMovement.timer_level1 = 0; PlayerMovement.timer_level2 = 0; PlayerMovement.timer_level3 = 0;
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(++_activeSceneBuildIndex);
    }
    public void FinishReached()
    {
        LoadNextLevel();
        Debug.Log("finish reached");
    }

}