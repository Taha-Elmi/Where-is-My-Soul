using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutUs : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject howToPlayObj;
   

    private int numberOfPages;
    private Sprite[] noteBookPages;
    private int page;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void HowToPalyButton()
    {
        // menuUI.SetActive(false);
        howToPlayObj.SetActive(true);
        page = 0;

        numberOfPages = 1;
        LoadInitData();
        howToPlayObj.GetComponent<Image>().sprite = noteBookPages[0];
    }
    private void LoadInitData()
    {
        noteBookPages = new Sprite[numberOfPages];

       
            noteBookPages[0] = Resources.Load<Sprite>("Sprites/AboutUs/aboutus");
       
    }
    public void exit()
	{
        Application.Quit();
	}
    public void closeButtonOnClick()
    {
        howToPlayObj.SetActive(false);
        menuUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
