using System.Collections;
using System.Runtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {

    public int time = 1000;
    public Text score;
    public Text lives;
    public Text t;

    public float speed;
    public float spin;

    public int timer = 20;

    public GameObject bullet;
    public GameObject enemy;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("frags", 0);
        PlayerPrefs.SetInt("bads", 0);
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("fired", 0);
    }
	
	// Update is called once per frame
	void Update () {
        t.text = time.ToString();
        time--;

        int s = 0;
        s = 10000 * PlayerPrefs.GetInt("lives") + 5000 * PlayerPrefs.GetInt("frags") - 100 * PlayerPrefs.GetInt("fired");
        score.text = s.ToString();
        lives.text = PlayerPrefs.GetInt("lives").ToString();
        if (PlayerPrefs.GetInt("lives") <= 0||time<=0) {
            PlayerPrefs.SetInt("final", s);
            SceneManager.LoadScene(2);
            SceneManager.UnloadScene(1);
        }
        //int b = PlayerPrefs.GetInt("bads");

        if (PlayerPrefs.GetInt("bads") < 2) {
            Spawn();
            PlayerPrefs.SetInt("bads", PlayerPrefs.GetInt("bads") + 1);
        }
        timer--;
        //speed = speed * 0.9f;

        if (transform.position.x<-1.15f||transform.position.x>1.15f||transform.position.y<-.55||transform.position.y>.55) {
            PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
            gameObject.transform.position = new Vector3(0, 0, -1);
            //collision.gameObject.transform.rotation = Quaternion.identity;
            //collision.gameObject.GetComponent<Rigidbody2D>().inertia = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0f, moveVertical);
        rb2d.AddRelativeForce(movement * speed);
        spin = moveHorizontal * -.01f;
        rb2d.AddTorque(spin);

        if (timer <=0 && .0f!=Input.GetAxis("Fire1")) {
            Fire();
            PlayerPrefs.SetInt("fired", PlayerPrefs.GetInt("fired") + 1);
            timer = 20;
        }
        
    }

    void Spawn() {
        GameObject E;
        float x = 0f;
        float y = 0f;
        //UnityEngine.Random rand = new UnityEngine.Random();
        int n = Random.Range(0, 3);
        switch (n) {
            case (0):
                x = Random.Range(-1.2f, 1.2f);
                y = .55f;
                break;
            case (1):
                x = Random.Range(-1.2f, 1.2f);
                y = -.55f;
                break;
            case (2):
                y = Random.Range(-.55f, .55f);
                x = 1.2f;
                break;
            case (3):
                y = Random.Range(-.55f, .55f);
                x = -1.2f;
                break;
        }
        float rot_z = Mathf.Atan2(x-transform.position.x, y-transform.position.y) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion(0, 0, rot_z , 0);

        E = (Instantiate(enemy, new Vector3(x,y,-1), new Quaternion(0, 0, rot_z, 0)));
        E.GetComponent<Rigidbody2D>().transform.LookAt(transform);
        E.GetComponent<Rigidbody2D>().AddRelativeForce(E.GetComponent<Rigidbody2D>().transform.forward * -20f);
        E.transform.rotation = rotation;
        //E.GetComponent<Rigidbody2D>().AddRelativeForce(E.GetComponent<Rigidbody2D>().transform.forward*10);
    }

    void Fire() {
        GameObject B;
        Vector3 v = new Vector3(rb2d.transform.position.x, rb2d.transform.position.y, -1f);
        
        B = (Instantiate(bullet, v, rb2d.transform.rotation));
        //B.transform.position = new Vector3(B.transform.position.x + B.transform.forward.x*2, B.transform.position.y + B.transform.forward.y*2, -1f);
        Vector2 direction = new Vector2(0f, 50f);
        //rb2d.transform.localPosition
        //B.GetComponent<Rigidbody2D>().;
        B.GetComponent<Rigidbody2D>().AddRelativeForce(direction);
    }
}

