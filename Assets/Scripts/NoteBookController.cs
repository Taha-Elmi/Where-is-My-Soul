using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookController : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject closeButton;
    public int noteBookPageNumber;
    private SpriteRenderer spriteRenderer;
    public Sprite[] noteBookPages;
    private int currentPgNum=0;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        noteBookPages = new Sprite[noteBookPageNumber];

        for (int i = 0; i < noteBookPageNumber; i++)
        {
            Sprite page = Resources.Load<Sprite>("Sprites/page"+ i.ToString());
            noteBookPages[i] = page;
        }
        spriteRenderer.sprite = noteBookPages[currentPgNum];


    }
    private void Awake()
	{
       
    }

    // Update is called once per frame
    void Update()
    {
        
	
    }
    public void setPage(int pagingValue)
    {
        if (currentPgNum + pagingValue != noteBookPageNumber && currentPgNum + pagingValue != -1) { 
        currentPgNum += pagingValue;
        spriteRenderer.sprite = noteBookPages[currentPgNum];
    }
    }
    
}
