using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int layer;
    public int soul;
    public string realTimeLabel;
    public int layerTime;
    private Timer realTimeTimer;
    private DateTime realDateTime;
    private Timer layerTimeTimer;

    // Start is called before the first frame update
    void Start()
    {
        layer = 1;
        soul = 0;
        SetTimers();
    }

    private void RealTimeTick(object sender, EventArgs e)
    {
        realDateTime.AddMinutes(1);
        realTimeLabel = realDateTime.ToString("HH:mm");
    }

    private void LayerTimeTick(object sender, EventArgs e)
    {
        layerTime--;
    }

    private void SetTimers()
    {
        realDateTime = new DateTime(2022, 10, 10, 0, 0, 0);
        realTimeTimer = new Timer
        {
            Interval = 500
        };
        realTimeTimer.Elapsed += RealTimeTick;
        realTimeTimer.Enabled = true;
        layerTimeTimer = new Timer
        {
            Interval = 1000
        };
        layerTimeTimer.Elapsed += LayerTimeTick;
        layerTimeTimer.Enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
