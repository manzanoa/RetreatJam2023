using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CopsDeployed : MonoBehaviour
{
    [SerializeField] CountDownTimer timer;
    public bool copsDepolyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.countDownTimer <= 30 && copsDepolyed == false) { 
            copsDepolyed = true;
        }
        
    }
}
