using System.Timers;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WhereIsMySoulManager : MonoBehaviour
{
    public int layer;
    public int soul;
    public string realTimeLabel;
    public int layerTime;
    public GameObject starParent;
    public GameObject soulGrabberParent;
    public GameObject gameObject;
    public Transform temp;
    
    private Timer realTimeTimer;
    private DateTime realDateTime;
    private static DateTime looseTime = new DateTime(2022, 10, 10, 8, 0, 0);
    private static int layerTimeInitialValue = 60;
    private static int realTimeInitialValue = 2000;
    private static string deathSceneName = "death"; 
    private static string awakeningSceneName = "awakening"; 
    private Timer layerTimeTimer;
    private Transform[] stars;
    private GameObject[] starsObjs;
    private Transform[] soulGrabbers;
    private int currentStar;
    private int currentSoulGrabber;
    private Timer objectFallTimer;

    private GameObject[] starChildren;

    // Start is called before the first frame update
    void Start()
    {
        layer = 1;
        soul = 0;
        stars = starParent.transform.GetComponentsInChildren<Transform>(true);
        currentStar = 1;
        starsObjs = new GameObject[stars.Length];
        for (int i = 0; i < stars.Length; i++)
        {
            starsObjs[i] = stars[i].gameObject;
        }
        soulGrabbers = soulGrabberParent.GetComponentsInChildren<Transform>(true);
        currentSoulGrabber = 1;

        SetTimers();
        realTimeTimer.Start();
        layerTimeTimer.Start();
        objectFallTimer.Start();
    }

    private void OnDestroy()
    {
        realTimeTimer.Stop();
        layerTimeTimer.Stop();
        objectFallTimer.Stop();
    }

    private void RealTimeTick(object sender, EventArgs e)
    {
        realDateTime = realDateTime.AddMinutes(1);
        realTimeLabel = realDateTime.ToString("HH:mm");
        if (realDateTime >= looseTime)
        {
            GameOver();
        }
    }

    private void LayerTimeTick(object sender, EventArgs e)
    {
        layerTime--;
        if (layerTime <=0)
        {
            downLayer();
        }
    }


    private GameObject getGameObjectFromTransform(Transform t)
    {
        return t.gameObject;
    }
    
    private void ObjectFall(object sender, EventArgs e)
    {
        if (soul == 0 || Random.value < 0.5)
        {
            gameObject = starsObjs[currentStar];
            
            print("soul");
            print("the index is: " + currentStar);
            print("len stars is: " + stars.Length);

            currentStar++;
            if (currentStar >= stars.Length)
            {
                currentStar = 1;
            }

        }
        else
        {
            print("grabber");
            gameObject = soulGrabbers[currentSoulGrabber].gameObject;

            currentSoulGrabber++;
            if (currentSoulGrabber >= soulGrabbers.Length)
            {
                currentSoulGrabber = 1;
            }
        }

        // float x = Random.Range(-7, 7);
        float x = 5.0f;
        print("before pos set");
        gameObject.transform.position.Set(x, gameObject.transform.position.y, gameObject.transform.position.z);
        print("after pos set");
        
        gameObject.SetActive(true);
        print("activated");
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
            Interval = realTimeInitialValue
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
        
        objectFallTimer = new Timer
        {
            Interval = 2000
        };
        objectFallTimer.Elapsed += ObjectFall;
        objectFallTimer.Enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (soul >= 100)
        {
            upLayer();
        } 
    }

    public void GameOver()
    {
        realTimeTimer.Stop();
        layerTimeTimer.Stop();
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
        layerTimeTimer.Stop();
        realTimeTimer.Stop();
        SceneManager.LoadScene(awakeningSceneName);
    }

    public void ResetForNewLayer()
    {
        layerTimeTimer.Stop();
        realTimeTimer.Interval = (realTimeInitialValue / layer);
        soul = 0;
        layerTime = layerTimeInitialValue;
        layerTimeTimer.Start();
    }
}
