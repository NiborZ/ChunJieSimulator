using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainTimer : MonoBehaviour
{
    public float maxTime;
    float timer;
    bool pause;

    private void Awake() {
        timer = maxTime;
    }

    void Update() {
        if (timer > 0 && !pause) {
            timer = Mathf.Max(timer - Time.deltaTime, 0);
            float percentage = timer / maxTime;
            GetComponent<Slider>().value = percentage;
            if (timer == 0) {
                OnTimeOut();
            }
        }
    }

    public void OnTimeOut() {
        Debug.Log("Time Out");

    }

    public void Stop() {
        pause = true;
    }
}
