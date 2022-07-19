using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteBookController : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject closeButton;
    public int noteBookPageNumber;
    private Image image;
    public Sprite[] noteBookPages;
    private int currentPgNum=0;
    
    // Start is called before the first frame update
    void Start()
    {
       

    }
    private void Awake()
	{
        loadInitData();

    }

    // Update is called once per frame
    void Update()
    {
        
	
    }
    public void loadInitData()
	{
        image = this.GetComponent<Image>();
        noteBookPages = new Sprite[noteBookPageNumber];

        for (int i = 0; i < noteBookPageNumber; i++)
        {
            Sprite page = Resources.Load<Sprite>("Sprites/page" + i.ToString());
            noteBookPages[i] = page;
        }
        image.sprite = noteBookPages[currentPgNum];
    }
    public void setPage(int pagingValue)
    {
        if (currentPgNum + pagingValue != noteBookPageNumber && currentPgNum + pagingValue != -1) { 
        currentPgNum += pagingValue;
        image.sprite = noteBookPages[currentPgNum];
    }
    }
    
}
