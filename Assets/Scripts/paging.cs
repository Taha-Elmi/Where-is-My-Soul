using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paging : MonoBehaviour
{
    public int pagingValue;
    public GameObject noteBook;
    NoteBookController noteBookController;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	private void Awake()
	{
        noteBookController = noteBook.GetComponent<NoteBookController>();
	}
	// Update is called once per frame
	void Update()
    {
       
    }
	private void OnMouseDown()
	{
        noteBookController.setPage(pagingValue);
	}
}
