using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EggScript : MonoBehaviour
{
    public float eggspeed;
    public float egglife;
    public Rigidbody2D rb;
    public Vector2 screenbounds;
    public GameObject Eggtext;
    public Eggcount eggnum;
    // Start is called before the first frame update
    void Start()
    {
        //adds one to the egg counter
        Eggtext = GameObject.Find("Text");
        eggnum = Eggtext.GetComponent<Eggcount>();
        eggnum.forceaddegg();
        //gets screen bounds
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,
            Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        //destroys and removes 1 from egg count
        rb.AddForce(eggspeed * transform.up);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //destroy when egg reaches screen
        Vector3 colbounds = transform.position;
        if (colbounds.x >= screenbounds.x  || colbounds.x <= screenbounds.x * -1f)
        {
            eggnum.count -= 1;
            Destroy(gameObject);
        }
        else if (colbounds.y >= screenbounds.y || colbounds.y <= screenbounds.y * -1f)
        {
            eggnum.count -= 1;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //egg collides with checkpoint the check point takes damage and destroys the egg
        if(col.gameObject.layer == 8)
        {
            CheckPointScript ckp = col.GetComponent<CheckPointScript>();
            ckp.takedamage();
            eggnum.count -= 1;
            Destroy(gameObject);
        }
        //egg collides with plane respawns the plane with egg being destroyed
        else if (col.gameObject.layer == 9)
        {
            EnemyBehavior ckp = col.GetComponent<EnemyBehavior>();
            ckp.respawn();
            eggnum.count -= 1;
            Destroy(gameObject);
        }
    }
}
