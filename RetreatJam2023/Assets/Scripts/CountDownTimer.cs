using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public float countDownTimer = 60f;
    [SerializeField] WinOrLoseCondition WinOrLoseCondition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!WinOrLoseCondition.winCondition)
        {
            countDownTimer -= Time.deltaTime;
        }
    }
}
