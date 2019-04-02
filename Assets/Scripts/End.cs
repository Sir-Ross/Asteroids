using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour {
    public Text[] scores;
    public Text final;
    public int[] s;
	// Use this for initialization
	void Start () {
        s[0] = PlayerPrefs.GetInt("1");
        s[1] = PlayerPrefs.GetInt("2");
        s[2] = PlayerPrefs.GetInt("3");
        s[3] = PlayerPrefs.GetInt("4");
        s[4] = PlayerPrefs.GetInt("5");
        

        for (int i=0;i<5;i++){
            if (PlayerPrefs.GetInt("final") > s[i]) {
                for(int j = i+1; j < 5; j++) {
                    s[j] = s[j - 1];
                }
                s[i] = PlayerPrefs.GetInt("final");
                break;
            }
        }

        final.text = PlayerPrefs.GetInt("final").ToString();
        scores[0].text = (PlayerPrefs.GetInt("1").ToString());
        scores[1].text = (PlayerPrefs.GetInt("2").ToString());
        scores[2].text = (PlayerPrefs.GetInt("3").ToString());
        scores[3].text = (PlayerPrefs.GetInt("4").ToString());
        scores[4].text = (PlayerPrefs.GetInt("5").ToString());



        PlayerPrefs.SetInt("1", s[0]);
        PlayerPrefs.SetInt("2", s[1]);
        PlayerPrefs.SetInt("3", s[2]);
        PlayerPrefs.SetInt("4", s[3]);
        PlayerPrefs.SetInt("5", s[4]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Retry() {
        SceneManager.LoadScene(1);
        SceneManager.UnloadScene(2);
    }

    public void Retire() {
        SceneManager.LoadScene(0);
        SceneManager.UnloadScene(2);
    }
}
