using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WhereIsMySoulManager : MonoBehaviour
{
    public int layer;
    public int soul;
    public Text clock;
    public SpriteRenderer fallIcon;
    public int layerTime;
    public int maxSouls;
    public GameObject starParent;
    public GameObject soulGrabberParent;
    public double fallPeriod;
    public double realTimePeriod;
    public double layerTimePeriod;
    public GameObject theKid;

    private float realTimeTimer;
    private DateTime realDateTime;
    private static DateTime looseTime = new DateTime(2022, 10, 10, 6, 0, 0);
    private static DateTime initialRealTime = new DateTime(2022, 10, 10, 0, 0, 0);
    private static int layerTimeInitialValue = 20;
    private static double realTimePeriodInitialValue = 0.25;
    private static double fallTimePeriodInitialValue = 0.2;
    private static string deathSceneName = "death"; 
    private static string awakeningSceneName = "awakening";
    private float layerTimeTimer;
    private Transform[] stars;
    private Transform[] soulGrabbers;
    private int currentStar;
    private int currentSoulGrabber;
    private float fallTime;
    public double fallIconSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        layer = 1;
        soul = 0;
        maxSouls = 12;
        fallPeriod = fallTimePeriodInitialValue;
        fallTime = 0;
        stars = starParent.transform.GetComponentsInChildren<Transform>(true);
        currentStar = 1;
        soulGrabbers = soulGrabberParent.GetComponentsInChildren<Transform>(true);
        currentSoulGrabber = 1;
        realDateTime = initialRealTime;
        layerTimePeriod = 1;
        realTimePeriod = 0.25;
        layerTimeTimer = 0;
        realTimeTimer = 0;
        fallIconSpeed = -0.75;
        layerTime = layerTimeInitialValue;
        ResetObjectPositions();
    }

    private void RealTimeTick()
    {
        realDateTime = realDateTime.AddMinutes(1);
        clock.text = realDateTime.ToString("HH:mm");
        if (realDateTime >= looseTime)
        {
            GameOver();
        }
    }

    private void LayerTimeTick()
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

    // Update is called once per frame
    void Update()
    {
        fallTime += 1.0f * Time.deltaTime;
        realTimeTimer += 1.0f * Time.deltaTime;
        layerTimeTimer += 1.0f * Time.deltaTime;

        if (layerTimeTimer >= layerTimePeriod)
        {
            LayerTimeTick();
            layerTimeTimer = 0;
        }
        if (realTimeTimer >= realTimePeriod)
        {
            RealTimeTick();
            fallIcon.transform.Translate(0, (float)fallIconSpeed * Time.deltaTime, 0);
            realTimeTimer = 0;
        }
        if (fallTime >= fallPeriod)
        {
            ObjectFall();
            fallTime = 0;
        }
        
        if (soul >= maxSouls)
        {
            upLayer();
        } 
    }

    public void GameOver()
    {
        ResetObjectPositions();
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
        ResetObjectPositions();
        SceneManager.LoadScene(awakeningSceneName);
    }

    public void ResetForNewLayer()
    {
        fallPeriod = fallTimePeriodInitialValue * layer;
        realTimePeriod = realTimePeriodInitialValue + ((layer - 1) * 0.25);
        soul = 0;
        layerTime = layerTimeInitialValue + ((layer - 1) * 5);
        ResetObjectPositions();
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
