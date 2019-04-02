using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public AudioSource boom;
    //public ParticleSystem particle;
	// Use this for initialization
	void Start () {
        Vector3 moveDirection = gameObject.transform.position;
        if (moveDirection != Vector3.zero) {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        }
        if (gameObject.name != "Enemy") {
           // transform.LookAt(Vector2.zero);


            //gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(transform.forward*10f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Enemy(Clone)") {
            if (transform.position.x < -2f || transform.position.x > 2f || transform.position.y < -1f || transform.position.y > 1f) {
            PlayerPrefs.SetInt("bads", PlayerPrefs.GetInt("bads") - 1);
                //particle.Play();
                boom.Play();
            Destroy(gameObject);

            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log(collision);

        if (collision.gameObject.name == "Ship") {
            gameObject.GetComponent<ParticleSystem>().Play();
            PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives")-1);
            collision.gameObject.transform.position = new Vector3(0, 0, 0);
            //collision.gameObject.transform.rotation = Quaternion.identity;
            //collision.gameObject.GetComponent<Rigidbody2D>().inertia = 0;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            PlayerPrefs.SetInt("bads",PlayerPrefs.GetInt("bads")-1);
            boom.Play();
            Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().duration);
        }
    }
}
