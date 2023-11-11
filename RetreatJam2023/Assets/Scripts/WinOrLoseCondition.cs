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
        if(allCampers.Count == 0)
        {
            winCondition = true;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        allCampers = FindObjectsOfType<CamperMovement>().ToList<CamperMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.countDownTimer <= 0)
        {
            loseCondition = true;
        }
       
        Debug.Log(timer.countDownTimer);
        Debug.Log(allCampers.Count);
    }
}
