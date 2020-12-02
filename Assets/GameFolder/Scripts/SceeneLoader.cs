using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceeneLoader : MonoBehaviour
{
    // Status status;


    /*private void Start()
    {
        status = FindObjectOfType<Status>();
    }*/
    Status AutoPlay;

    private void Start()
    {
        AutoPlay = FindObjectOfType<Status>();      
    }

    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);  
    }
    public void LoadStartSceneAuto()
    {
        AutoPlay.IsAutoPlayEnabled();
        SceneManager.LoadScene(0);


    }
    public void LoadStartScene()
    {
        //status.reset();
        SceneManager.LoadScene(0);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
