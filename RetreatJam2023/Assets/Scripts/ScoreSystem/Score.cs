using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] WinOrLoseCondition winOrLoseCondition;
    [SerializeField] float rampageTimeInterval = 3; //amount of time you stayin RampageMode
    [SerializeField] int scoreAmountInRampage = 5; //this is how many points the player recevies while in rampage
    [SerializeField] int scoreAmountNonRampage = 1; // how many points while not in rampage 
    public int playerScore = 0;
    public bool rampageMode = false;
    int currentCamperCount;
    float rampageTimer;
    float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.deltaTime;
        RampagePointsChecker();
        currentCamperCount = winOrLoseCondition.allCampers.Count;
        SetRampageMode();
    }

    void RampagePointsChecker()
    {
        if (winOrLoseCondition.allCampers.Count < currentCamperCount)
        {
            AddScorePoints();
            RampageTimerAddTime();
        }
    }

    void AddScorePoints()
    {
        if (rampageMode)
        {
            playerScore += scoreAmountInRampage;
        }
        else
        {
            playerScore += scoreAmountNonRampage;
        }
    }

    void RampageTimerAddTime()
    {
        rampageTimer += rampageTimeInterval;
    }

    void SetRampageMode()
    {
        if (rampageTimer <= 0)
        {
            rampageMode = false;
            rampageTimer = 0;
        }
        else
        {
            rampageMode = true;
            rampageTimer -= currentTime;
        }
    }
}
