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
    Sprite[] noteBookPages;
    private int currentPgNum=0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = noteBookPages[currentPgNum];

    }
    private void Awake()
	{
        for (int i = 0; i < noteBookPageNumber; i++)
        {
            Sprite page = Resources.Load("page" + i, typeof(Sprite)) as Sprite;
            noteBookPages[i] = page;
        }
    }

	// Update is called once per frame
	void Update()
    {
        
	
    }
    public void setPage(int pagingValue)
	{
        currentPgNum+=pagingValue;
        spriteRenderer.sprite = noteBookPages[currentPgNum];
    }
    
}
