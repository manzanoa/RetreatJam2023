using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    bool menuOpen = false;
    [SerializeField] GameObject MenuGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuOpen)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    void OpenMenu()
    {
        MenuGameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        MenuGameObject.SetActive(false);

    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
