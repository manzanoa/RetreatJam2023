using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject OutcomeWindow;
    [SerializeField] Text timer;
    [SerializeField] Text camperCount;
    public void Win()
    {
        OutcomeWindow.SetActive(true);
        OutcomeWindow.GetComponent<OutcomeScript>().win = true;
    }

    public void Lose()
    {
        OutcomeWindow.SetActive(true);
        OutcomeWindow.GetComponent<OutcomeScript>().win = false;
        timer.text = "0:00";
    }

    private void Update()
    {
    }

    public void UpdateTimer(float time)
    {
         float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string secondsText = seconds.ToString();
        if (seconds < 10)
        {
            secondsText = "0"+seconds.ToString();
        }
        timer.text = minutes.ToString() + ":" + secondsText;
    }

    public void UpdateCamperCount(int count)
    {
        camperCount.text = count.ToString();
    }

}
