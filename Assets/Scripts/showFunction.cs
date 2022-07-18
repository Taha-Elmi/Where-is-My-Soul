using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showFunction : MonoBehaviour
{
    public static GameObject fuctionPage;
    // Start is called before the first frame update
    void Start()
    {
        fuctionPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnMouseDown()
	{
        fuctionPage.SetActive(true);
	}
}
