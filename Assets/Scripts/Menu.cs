using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Begin() {
        SceneManager.LoadScene(1);
        SceneManager.UnloadScene(0);
    }

    public void Settings() {
        SceneManager.LoadScene(3);
        SceneManager.UnloadScene(0);
    }

    public void  Quit() {
        Application.Quit();
    }
}
