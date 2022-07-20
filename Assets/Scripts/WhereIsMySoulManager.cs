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
    public int maxSouls;
    public GameObject starParent;
    public GameObject soulGrabberParent;
    public float fallPeriod;
    public GameObject theKid;
    
    private Timer realTimeTimer;
    private DateTime realDateTime;
    private static DateTime looseTime = new DateTime(2022, 10, 10, 8, 0, 0);
    private static int layerTimeInitialValue = 20;
    private static int realTimeInitialValue = 250;
    private static string deathSceneName = "death"; 
    private static string awakeningSceneName = "awakening"; 
    private Timer layerTimeTimer;
    private Transform[] stars;
    private Transform[] soulGrabbers;
    private int currentStar;
    private int currentSoulGrabber;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        layer = 1;
        soul = 0;
        maxSouls = 10;
        fallPeriod = 2;
        time = 0;
        stars = starParent.transform.GetComponentsInChildren<Transform>(true);
        currentStar = 1;
        soulGrabbers = soulGrabberParent.GetComponentsInChildren<Transform>(true);
        currentSoulGrabber = 1;

        SetTimers();
        realTimeTimer.Start();
        layerTimeTimer.Start();
    }

    private void OnDestroy()
    {
        realTimeTimer.Stop();
        layerTimeTimer.Stop();
        ResetObjectPositions();
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

    private void ObjectFall()
    {
        GameObject fallObject;
        if (soul == 0 || Random.value < 0.5)
        {
            fallObject = stars[currentStar].gameObject;

            currentStar++;
            if (currentStar >= stars.Length)
            {
                currentStar = 1;
            }

        }
        else
        {
            fallObject = soulGrabbers[currentSoulGrabber].gameObject;

            currentSoulGrabber++;
            if (currentSoulGrabber >= soulGrabbers.Length)
            {
                currentSoulGrabber = 1;
            }
        }

        fallObject.SetActive(true);
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
    }

    // Update is called once per frame
    void Update()
    {
        time += 1.0f * Time.deltaTime;
        if (time >= fallPeriod)
        {
            print("I'm here.");
            ObjectFall();
            time = 0;
        }
        
        if (soul >= maxSouls)
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
        realTimeTimer.Interval = realTimeInitialValue + (layer * 250);
        soul = 0;
        layerTime = layerTimeInitialValue + (layer * 5);
        ResetObjectPositions();
        layerTimeTimer.Start();
    }

    private void ResetObjectPositions()
    {

        for (int i = 1; i < stars.Length; i++)
        {
            GameObject obj = stars[i].gameObject;
            obj.gameObject.SetActive(false);
            float x = Random.Range(-7, 7);
            obj.gameObject.transform.position = new Vector3(x, 6.0f, 0);
        }

        for (int i = 1; i < soulGrabbers.Length; i++)
        {
            GameObject obj = soulGrabbers[i].gameObject;
            obj.gameObject.SetActive(false);
            float x = Random.Range(-7, 7);
            obj.gameObject.transform.position = new Vector3(x, 6.0f, 0);
        }

        Color color = theKid.GetComponent<SpriteRenderer>().color;
        Color newColor = new Color(color.r, color.g, color.b, 0.01f);
        theKid.GetComponent<SpriteRenderer>().color = newColor;
    }
}
