using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(0); //так лучше
        //Application.LoadLevel(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
