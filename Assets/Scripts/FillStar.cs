using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FillStar : MonoBehaviour
{
    public WhereIsMySoulManager manager;
    public SpriteRenderer theKid;
    public GameObject star;
    public bool activated;
    
    private Color _color;
    private Random _random = new Random();

    private void Start()
    {
        activated = false;
        _color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.gray;
        SetPosition();
    }

    private void Update()
    {
        if (!activated && Vector3.Distance(transform.position, star.transform.position) < 0.1
                       && Math.Abs((transform.rotation.z - star.transform.rotation.z) % 360) < 0.1)
        {
            activated = true;
            GetComponent<SpriteRenderer>().color = _color;
            star.transform.position = new Vector3(-6.63f, -1.68f, 0);
            star.transform.rotation = new Quaternion(0, 0, 0, 0);

            manager.soul++;
            Color color = theKid.color;
            Color newColor = new Color(color.r, color.g, color.b, 0);
            newColor.a = ((float)manager.soul) / manager.maxSouls;
            theKid.color = newColor;
        }
    }

    private void SetPosition()
    {
        /* didn't work
        float y = 0;
        if (gameObject.name.EndsWith("(0)"))
        {
            y = GetRandomInRange(-4.3f, -2.3f);
        }
        else if (gameObject.name.EndsWith("(1)"))
        {
            y = GetRandomInRange(-0.3f, 1.0f);
        }
        else if (gameObject.name.EndsWith("(2)"))
        {
            y = GetRandomInRange(3.0f, 4.0f);
        }

        float r = _random.Next(360);
        
        transform.position = new Vector3(2.6f, y, 0);
        transform.rotation = new Quaternion(0, 0, r, 0);
        */

        float[] nums = {25, 78, 100, 120, 150, 180, 210, 250, 280, 310, 240};

        int num = _random.Next() % nums.Length;

        transform.rotation.Set(0, 0, nums[num], 0);
    }

    private float GetRandomInRange(float a, float b)
    {
        float range = b - a;
        float num = (float)_random.NextDouble();
        num *= range;
        num += a;
        return num;
    }
}
