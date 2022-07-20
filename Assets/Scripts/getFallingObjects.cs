using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFallingObjects : MonoBehaviour
{

    public WhereIsMySoulManager manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.StartsWith("star"))
        {
            manager.soul++;
        }
        else
        {
            manager.soul--;
        }

        other.gameObject.SetActive(false);
        float x = Random.Range(-7, 7);
        other.gameObject.transform.position = new Vector3(x, 6.0f, 0);
        
        Color color = GetComponent<SpriteRenderer>().color;
        Color newColor = new Color(color.r, color.g, color.b, 0);
        newColor.a = ((float)manager.soul) / manager.maxSouls;
        GetComponent<SpriteRenderer>().color = newColor;
    }
}
