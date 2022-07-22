using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingStar : MonoBehaviour
{
    public Transform shootingPos;
    public GameObject star;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            shoot();
		}
        
    }
    void shoot()
	{
        GameObject starShoot = Instantiate(star, shootingPos.position, shootingPos.rotation);
        starShoot.GetComponent<Rigidbody2D>().AddForce(starShoot.transform.up * speed);
	}
}
