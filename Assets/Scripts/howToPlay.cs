using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class howToPlay : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject howToPlayObj;
    public Button left;
    public Button right;

    private int numberOfPages;
    private Sprite[] noteBookPages;
    private int page;

    public void HowToPalyButton()
    {
        // menuUI.SetActive(false);
        howToPlayObj.SetActive(true);
        page = 0;
        left.interactable = false;
        right.interactable = true;
        numberOfPages = 3;
        LoadInitData();
        howToPlayObj.GetComponent<Image>().sprite = noteBookPages[0];
    }

    public void rightButtonOnClick()
    {
        page++;
        howToPlayObj.GetComponent<Image>().sprite = noteBookPages[page];

        left.interactable = true;
        if (page == numberOfPages - 1)
        {
            right.interactable = false;
        }
    }

    public void leftButtonOnClick()
    {
        page--;
        howToPlayObj.GetComponent<Image>().sprite = noteBookPages[page];

        right.interactable = true;
        if (page == 0)
        {
            left.interactable = false;
        }
    }

    public void closeButtonOnClick()
    {
        howToPlayObj.SetActive(false);
        menuUI.SetActive(true);
    }

    private void LoadInitData()
    {
        noteBookPages = new Sprite[numberOfPages];

        for (int i = 0; i < numberOfPages; i++)
        {
            noteBookPages[i] = Resources.Load<Sprite>("Sprites/HowToPlay/mode" + i.ToString());
        }
    }
}
