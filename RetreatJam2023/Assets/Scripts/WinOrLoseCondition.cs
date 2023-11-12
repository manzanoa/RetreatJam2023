using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WinOrLoseCondition : MonoBehaviour
{

    [SerializeField] CountDownTimer timer;
    public List<CamperMovement> allCampers;
    public bool winCondition = false;
    public bool loseCondition = false;
    public void CamperDied(CamperMovement camper)
    {
        allCampers.Remove(camper);
        FindObjectOfType<UIController>().UpdateCamperCount(allCampers.Count);
        if (allCampers.Count == 0)
        {
            winCondition = true;
            FindObjectOfType<UIController>().Win();
            Time.timeScale = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        allCampers = FindObjectsOfType<CamperMovement>().ToList();
        FindObjectOfType<UIController>().UpdateCamperCount(allCampers.Count);
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<UIController>().UpdateTimer(timer.countDownTimer);
        if (timer.countDownTimer <= 0)
        {
            loseCondition = true;
            FindObjectOfType<UIController>().Lose();
            Time.timeScale = 0;

        }
    }
}
