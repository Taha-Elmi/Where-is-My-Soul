using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DeathPresenter : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public Button back;
    
    private SpriteRenderer pic1;
    private SpriteRenderer pic2;
    private float time;

    private void Start()
    {
        pic1 = obj1.GetComponent<SpriteRenderer>();
        pic2 = obj2.GetComponent<SpriteRenderer>();
        time = 0;
        back.image.color -= new Color(0, 0, 0, 1);
    }

    private void Update()
    {
        time += 1f * Time.deltaTime;

        if (time > 4)
        {
            pic1.color -= new Color(0, 0, 0, 0.25f * Time.deltaTime);
        }
        
        if (time > 12)
        {
            pic2.color -= new Color(0, 0, 0, 0.25f * Time.deltaTime);
        } 
        
        if (time > 20)
        {
            back.image.color += new Color(0, 0, 0, 0.5f * Time.deltaTime);
        }

        if (pic1.color.a <= 0)
        {
            obj2.SetActive(true);
        }

        if (pic2.color.a <= 0)
        {
            obj3.SetActive(true);

        }
    }
}
