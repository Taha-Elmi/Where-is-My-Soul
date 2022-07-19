using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        float x = Random.Range(-7, 7);
        other.gameObject.transform.position = new Vector3(x, 6.0f, 0);
    }
}
