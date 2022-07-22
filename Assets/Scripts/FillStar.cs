using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FillStar : MonoBehaviour
{
    public WhereIsMySoulManager manager;
    public SpriteRenderer theKid;
    public GameObject star;
    public bool activated;
    
    private Color _color;

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
                       && Math.Abs(transform.rotation.z - star.transform.rotation.z) < 0.1)
        {
            activated = true;
            GetComponent<SpriteRenderer>().color = _color;
            star.transform.position = new Vector3(-5, -3, 0);
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
        float y = 0;
        if (gameObject.name.EndsWith("(0)"))
        {
            y = Random.Range(-4.3f, -2.3f);
        }
        else if (gameObject.name.EndsWith("(1)"))
        {
            y = Random.Range(-0.3f, 1.0f);
        }
        else if (gameObject.name.EndsWith("(2)"))
        {
            y = Random.Range(3.0f, 4.0f);
        }

        float r = Random.Range(0, 360);
        
        transform.position = new Vector3(2.6f, y, 0);
        transform.rotation = new Quaternion(0, 0, r, 0);
    }
}
