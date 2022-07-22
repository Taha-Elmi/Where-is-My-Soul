using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour
{
    public float speed;
    public float fastRatio;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        fastRatio = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < 6.2)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                transform.Translate(speed * fastRatio * Time.deltaTime, 0, 0);

            }
            else
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);

            }
        }
        
        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.5)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                transform.Translate(-speed * fastRatio * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
