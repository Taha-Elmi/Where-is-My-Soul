using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string sceneName;
    
	public void OnMouseDown()
	{
        SceneManager.LoadScene(sceneName);
	}
}
