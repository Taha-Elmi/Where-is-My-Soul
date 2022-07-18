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
    private static DateTime looseTime = new DateTime(2022, 10, 10, 6, 0, 0);
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
        if (layerTime <=0)
        {
            downLayer();
        } 
    }

    private void downLayer()
    {
        layer += 1;
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
        layerTime = 60;
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
        if (realDateTime >= looseTime)
        {
            GameOver();
        }
        if (soul >= 100)
        {
            upLayer();
        } 
    }

    public void GameOver()
    {
        
    }

    private void upLayer()
    {
        layer -= 1;
        if (layer < 1)
        {
            Win();
        } 
    }

    public void Win()
    {
        
    }
}
