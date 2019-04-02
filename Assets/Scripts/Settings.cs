using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    [SerializeField]
    public Slider MusicVolume;
    [SerializeField]
    public Slider SFXVolume;


    // Use this for initialization
    void Start() {
        //DontDestroyOnLoad(this.gameObject);
        if (MusicVolume) MusicVolume.value = (PlayerPrefs.GetFloat("mv"));
        if (SFXVolume) SFXVolume.value = (PlayerPrefs.GetFloat("sv"));
    }

    // Update is called once per frame
    void Update() {
        if (MusicVolume) PlayerPrefs.SetFloat("mv", MusicVolume.value);
        if (SFXVolume) PlayerPrefs.SetFloat("sv", SFXVolume.value);
    }

    public void Return() {
        SceneManager.LoadScene(0);
        SceneManager.UnloadScene(3);
    }
}
