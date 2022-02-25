using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void SnakesButton()
    {

    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
