using System.Timers;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int layer;
    public int soul;
    public string realTimeLabel;
    public int layerTime;
    private Timer realTimeTimer;
    private DateTime realDateTime;
    private static DateTime looseTime = new DateTime(2022, 10, 10, 6, 0, 0);
    private static int layerTimeInitialValue = 60;
    private static string deathSceneName = "death"; 
    private static string awakeningSceneName = "awakening"; 
    private Timer layerTimeTimer;

    // Start is called before the first frame update
    void Start()
    {
        layer = 1;
        soul = 0;
        SetTimers();
        realTimeTimer.Start();
        layerTimeTimer.Start();
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
        ResetForNewLayer();
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
        layerTime = layerTimeInitialValue;
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
            return;
        }
        if (soul >= 100)
        {
            upLayer();
        } 
    }

    public void GameOver()
    {
        SceneManager.LoadScene(deathSceneName);

    }

    private void upLayer()
    {
        layer -= 1;
        if (layer < 1)
        {
            Win();
            return;
        }
        ResetForNewLayer();
    }

    public void Win()
    {
        SceneManager.LoadScene(awakeningSceneName);
    }

    public void ResetForNewLayer()
    {
        layerTimeTimer.Stop();
        soul = 0;
        layerTime = layerTimeInitialValue;
        layerTimeTimer.Start();
    }
}
