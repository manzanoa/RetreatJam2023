using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class MiniCopCar : MonoBehaviour
{
    //[SerializeField] GameObject RedLight;
   // [SerializeField] GameObject BlueLight;
    //private bool isLightOn = true;
    [SerializeField] CountDownTimer timer;

    //public float speed = 1.0f;
    //public float distance = 60.0f;
    //[SerializeField] Transform startPoint;
    //[SerializeField] Transform endPoint;
    [SerializeField] Slider copSlider;


    float startTime;
    float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = timer.countDownTimer;
        //distance = Vector2.Distance(startPoint.position, endPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating("LightBar", 0.5f, 0.5f);
        currentTime = Mathf.Abs(1 - (timer.countDownTimer / startTime));
        copSlider.value = currentTime;
      //  this.transform.position = new Vector2(startPoint.position.x + (distance * currentTime), this.transform.position.y);

    }

    //void LightBar()
    //{
    //    if (isLightOn)
    //    {
    //        BlueLight.SetActive(false);
    //        RedLight.SetActive(true);
    //        isLightOn = false;
    //    }
    //    else
    //    {
    //        RedLight.SetActive(false);
    //        BlueLight.SetActive(true);
    //        isLightOn = true;
    //    }
    //}
}
