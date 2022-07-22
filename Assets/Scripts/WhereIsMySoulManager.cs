using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WhereIsMySoulManager : MonoBehaviour
{
    public System.Random random;
    public int soul;
    public Text clock;
    public SpriteRenderer fallIcon;
    public SpriteRenderer sky1;
    public int layerTime;
    public int maxSouls;
    public GameObject starParent;
    public GameObject soulGrabberParent;
    public double layerTimePeriod;
    public GameObject theKid;
    public Text layerText;
    
    private static int layer = 3;
    private static double fallPeriod;
    private static double realTimePeriod;
    private static float realTimeTimer = 0;
    private static DateTime realDateTime = new DateTime(2022, 10, 10, 0, 0, 0);
    private static DateTime looseTime = new DateTime(2022, 10, 10, 6, 0, 0);
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
    private static double fallIconSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        layerText.text = "layer: " + layer.ToString();
        soul = 0;
        fallPeriod = fallTimePeriodInitialValue + ((layer - 1) * 0.1);
        fallTime = 0;
        layerTimePeriod = 1;
        realTimePeriod = realTimePeriodInitialValue + ((layer - 1) * 0.25);
        layerTimeTimer = 0;
        fallIconSpeed = -0.78;
        layerTime = layerTimeInitialValue + ((layer - 1) * 5);
        
        Color color = theKid.GetComponent<SpriteRenderer>().color;
        Color newColor = new Color(color.r, color.g, color.b, 0.1f);
        theKid.GetComponent<SpriteRenderer>().color = newColor;
        
        if (SceneManager.GetActiveScene().name.EndsWith("1"))
        {
            maxSouls = 26 - ((layer - 1) * 2);
            stars = starParent.transform.GetComponentsInChildren<Transform>(true);
            currentStar = 1;
            soulGrabbers = soulGrabberParent.GetComponentsInChildren<Transform>(true);
            currentSoulGrabber = 1;
            ResetObjectPositions();
        }
        else if (SceneManager.GetActiveScene().name.EndsWith("2"))
        {
            maxSouls = 20 - ((layer - 1) * 2);
        }
        else if (SceneManager.GetActiveScene().name.EndsWith("3"))
        {
            maxSouls = 3;
        }
    }
	private void Awake()
	{
        random = new System.Random();

    }

    private void RealTimeTick()
    {
        realDateTime = realDateTime.AddMinutes(1);
        clock.text = "Real Time:" + realDateTime.ToString("HH:mm:ss");
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
        sky1.color -= new Color(0, 0, 0, Time.deltaTime / layerTime);

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

        if (SceneManager.GetActiveScene().name.EndsWith("1"))
        {
            fallTime += 1.0f * Time.deltaTime;
            if (fallTime >= fallPeriod)
            {
                ObjectFall();
                fallTime = 0;
            }
        }
        
        if (soul >= maxSouls)
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
        fallPeriod = fallTimePeriodInitialValue + ((layer - 1) * 0.1);
        realTimePeriod = realTimePeriodInitialValue + ((layer - 1) * 0.25);
        soul = 0;
        layerTime = layerTimeInitialValue + ((layer - 1) * 5);
        layerText.text = "layer: " + layer.ToString();
        if (layer % 3 == 0)
        {
            SceneManager.LoadScene("GameScene1");
        }
        else if (layer % 3 == 2)
        {
            SceneManager.LoadScene("GameScene3");
        }
        else
        {
            SceneManager.LoadScene("GameScene2");
        }
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
        Color newColor = new Color(color.r, color.g, color.b, 0.1f);
        theKid.GetComponent<SpriteRenderer>().color = newColor;

        color = sky1.color;
        color.a = 1;
        sky1.color = color;
    }
}
