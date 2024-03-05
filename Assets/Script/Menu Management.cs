using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{

    // Start is called before the first frame update
    public void Nivel1()
    {
        Continue();
        SceneManager.LoadScene(1);
    }
    public void Nivel2()
    {
        Continue();
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }


}