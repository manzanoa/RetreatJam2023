using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, settings, tutorials, credits;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void Tutorial()
    {
        mainMenu.SetActive(false);
        tutorials.SetActive(true);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void Back()
    {
        
        settings.SetActive(false);
        tutorials.SetActive(false);
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
