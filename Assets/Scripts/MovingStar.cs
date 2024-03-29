using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MovingStar : MonoBehaviour
{
    public bool activated;
    public WhereIsMySoulManager manager;
    public SpriteRenderer theKid;
    public float speed;
    
    private Color _color;
    private void Start()
    {

		float y = manager.random.Next(2,5);
        Vector3 pos = transform.position;
        pos.y = y;
        //float randomDeltaX=manager.random.Next(-2,2);
        //pos.x = pos.x + randomDeltaX;
        transform.position = pos;
        
        _color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.gray;
        activated = false;

        speed = 3;
    }
    
    private void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -9.6)
        {
            float y = transform.position.y;
            transform.position = new Vector3(7.25f, y, 0);
            GetComponent<SpriteRenderer>().color = Color.gray;
            activated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated)
        {
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().color = _color;
            activated = true;
            
            manager.soul++;
            Color color = theKid.color;
            Color newColor = new Color(color.r, color.g, color.b, 0);
            newColor.a = ((float)manager.soul) / manager.maxSouls;
            theKid.color = newColor;
        }
    }
}
