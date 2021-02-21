using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Play()
    {
        SceneManager.LoadScene("Play");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
