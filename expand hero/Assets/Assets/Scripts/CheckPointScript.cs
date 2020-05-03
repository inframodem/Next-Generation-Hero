using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    
    public float damage = 1.0f;
    public Vector3 home;
    public SpriteRenderer sprite;
    public bool isvisible;
    public Eggcount eggnum;
    // Start is called before the first frame update
    void Start()
    {
        isvisible = true;
        home = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //toggle visibility
        if (Input.GetKeyDown(KeyCode.H))
        {
            isvisible = !isvisible;
        }
        if (!isvisible)
        {
            sprite.color = new Vector4(1f, 1f, 1f, 0f);
        }
        else
            sprite.color = new Vector4(1f, 1f, 1f, damage);
    }

    public void takedamage()
    {
        //remove 0.25 of alpha channel in color
        damage -= 0.25f;   
        //if alpha is zero move to random position around home position with damage and color set to 1
        if(damage <= 0f)
        {
            eggnum.enemiesKilled += 1;
            float xrand = Random.Range(-1.5f, 1.5f);
            float yrand = Random.Range(-1.5f, 1.5f);
            transform.position = new Vector3(home.x + xrand , home.y + yrand, home.z);
            damage = 1f;
            sprite.color = new Vector4(1f, 1f, 1f, 1f);
        }
    }
}
