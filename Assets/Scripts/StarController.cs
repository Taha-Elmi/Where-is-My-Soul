using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private float speed = 5;
    // private float slowRatio = 0.25f;
    private float rotateSpeed = 20;

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < 6.3)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        }
        
        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.5)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        }
        
        if (Input.GetKey(KeyCode.W) && transform.position.y < 5)
        {
            transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
        }
        
        if (Input.GetKey(KeyCode.S) && transform.position.y > -4.5)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }
}
