using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class awakeningDelay : MonoBehaviour
{
    private float time;

    private void Start()
    {
        time = 0;
    }

    private void Update()
    {
        time += 1.0f * Time.deltaTime;

        if (time >= 4)
        {
            SceneManager.LoadScene("SleepAgain");
        }
    }
}
