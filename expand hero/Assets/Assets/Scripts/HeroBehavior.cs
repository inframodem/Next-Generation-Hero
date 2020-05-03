using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Security.Cryptography;
//using System.Collections.Specialized;

public class HeroBehavior : MonoBehaviour {

    public EggStatSystem mEggStat = null;
    public float mHeroSpeed = 1f;
    public float kHeroRotateSpeed = 90f/2f; // 90-degrees in 2 seconds
    public Rigidbody2D rb;
    public bool mousemode;
    public Eggcount ui;
    // Use this for initialization

    void Start () {
        mousemode = true;
        Debug.Assert(mEggStat != null);
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //make velocity zero
        if (Input.GetKeyDown(KeyCode.P))
        {
            rb.velocity = rb.velocity.normalized * 0f;
        }
        //quit
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        //change mouse mode
        if (Input.GetKeyDown(KeyCode.M))
        {
            mousemode = !mousemode;
            ui.ismouse = mousemode;
        }
        if (!mousemode)
        {
            //cap velocity
            if (rb.velocity.sqrMagnitude > (10f * 10f))
            {
                rb.velocity = rb.velocity.normalized * 10f;
            }
            UpdateMotion();
        }
        else
        {
            //if it's mouse mode make the position of hero the same as the mouse position
            Vector3 mousescreenpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,transform.position.z);
            Vector3 mouseworldpos = Camera.main.ScreenToWorldPoint(mousescreenpos);
            mouseworldpos.z = 0f;
            transform.position = mouseworldpos;
        }
    }

    private void UpdateMotion()
    {
        //increase or decrease the hero velocity
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * mHeroSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(transform.up * -mHeroSpeed);
        }
        //rotate hero
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, kHeroRotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -kHeroRotateSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //if hero collides with enemy trigger the respawn method and add to enemies touched and enemies killed
        if (col.gameObject.layer == 9)
        {
            ui.entitiesTouched += 1;
            ui.enemiesKilled += 1;
            EnemyBehavior ckp = col.GetComponent<EnemyBehavior>();
            ckp.respawn();
            
        }
    }


}
