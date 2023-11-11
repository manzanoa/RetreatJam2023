using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLoseCondition : MonoBehaviour
{

    [SerializeField] CountDownTimer timer;
    public CamperMovement[] allCampers;

    public void CamperDied(CamperMovement camper)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        allCampers = FindObjectsOfType<CamperMovement>();
    }

    // Update is called once per frame
    void Update()
    {
     //   allCampers = FindObjectsOfType<CamperMovement>();
        Debug.Log(timer.countDownTimer);
        Debug.Log(allCampers.Length);
    }
}
