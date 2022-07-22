using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillStar : MonoBehaviour
{
    public GameObject star;
    public Sprite fullStar;
    
    private bool activated;
    private Color _color;

    private void Start()
    {
        activated = false;
        _color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void Update()
    {
        if (!activated && Vector3.Distance(transform.position, star.transform.position) < 0.1
                       && Math.Abs(transform.rotation.z - star.transform.rotation.z) < 0.1)
        {
            activated = true;
            GetComponent<SpriteRenderer>().color = _color;
            star.transform.position = new Vector3(-5, -3, 0);
            star.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
