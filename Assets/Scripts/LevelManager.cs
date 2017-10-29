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