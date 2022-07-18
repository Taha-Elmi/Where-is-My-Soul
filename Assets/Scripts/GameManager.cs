using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms.Timer;

public class GameManager : MonoBehaviour
{
    public int layer;
    public int soul;
    public string realTimeLabel;
    public string layerTimeLabel;
    private Timer realTimeTimer;
    private DateTime realDateTime;
    private Timer layerTimeTimer;
    private DateTime layerDateTime;

    // Start is called before the first frame update
    void Start()
    {
        layer = 1;
        soul = 0;
        realDateTime = new DateTime(2022, 10, 10, 0, 0);
        realTimeTimer = new Timer();
        realTimeTimer.Interval = 500;
        realTimeTimer.Tick = new EventHandler(RealTimeTick);
    }

    public void RealTimeTick(object sender, EventArgs e)
    {
        realTimeLabel = realDateTime.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
