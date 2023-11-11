using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutcomeScript : MonoBehaviour
{
    public bool win;
    public Text heading;

    //maybe change this to work on the same level
    // Start is called before the first frame update
    void Start()
    {
        if(win)
        {
            heading.text = "No Survivors";
        }
        else
        {
            heading.text = "Caught";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
