using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class changeScene : MonoBehaviour
{
    public string sceneName;
    
	public void OnMouseDown()
	{
        if (sceneName.Equals("GameScene1"))
        {
            WhereIsMySoulManager.layer = 3;
            WhereIsMySoulManager.realDateTime = new DateTime(2022, 10, 10, 0, 0, 0);
        }

        if (SceneManager.GetActiveScene().name.Equals("SleepAgain") || SceneManager.GetActiveScene().name.Equals("death"))
        {
	        GameObject obj = GameObject.Find("AudioManager");
	        obj.GetComponent<AudioSource>().Stop();
	        Destroy(obj);
        }
        
        SceneManager.LoadScene(sceneName);
        Destroy(this);
	}
}
