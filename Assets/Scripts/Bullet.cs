using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour {
    public AudioSource bang;
    //public ParticleSystem particle;
	// Use this for initialization
	void Start () {
        bang.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if(!(transform.position.x>2)){
        if (transform.position.x > 1.15f || transform.position.x < -1.15f || transform.position.y > .52f || transform.position.y < -.52f) {

                Destroy(gameObject);
            
        }
        }

        
	}
    
    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Enemy(Clone)" || collision.gameObject.name == "Enemy") {
            //Debug.Log("AFASF");
            PlayerPrefs.SetInt("frags", PlayerPrefs.GetInt("frags")+1);
            PlayerPrefs.SetInt("bads", PlayerPrefs.GetInt("bads") - 1);
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, collision.gameObject.GetComponent<ParticleSystem>().duration);

            Destroy(gameObject);

        }
    }
}
