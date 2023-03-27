using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTime : MonoBehaviour
{
    public static int currentScore;
    private float currentTime;

    private void Start()
    {
        currentScore = 0;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 1)
        {
            currentScore++;
            currentTime = 0;
        }
    }
}
