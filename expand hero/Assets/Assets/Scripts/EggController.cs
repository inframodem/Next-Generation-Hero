using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggController : MonoBehaviour
{
    public GameObject egg;
    public GameObject hero;
    public Scrollbar sb;
    public float eggSpawnRate = 0.25f;
    public float cooldown;
    public GameObject cooldownbar;
    public RectTransform bartrans;

    // Start is called before the first frame update
    void Start()
    {
        bartrans = cooldownbar.GetComponent<RectTransform>();
        bartrans.sizeDelta = new Vector2(10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //allows manipulation of egg spawn rate
        cooldown = cooldown - Time.deltaTime;
        //changes cooldown size to match spawnrate
        if(cooldown >= 0)
        {
            float barpercent = cooldown / eggSpawnRate;
            
            bartrans.sizeDelta = new Vector2(160f * barpercent, 10f);
        }
        else
            bartrans.sizeDelta = new Vector2(0, 10f);
        //spawns egg w/ space if cooldown is zero or less
        if (Input.GetKey(KeyCode.Space) && cooldown <= 0)
        {
            Instantiate(egg, hero.transform.position, hero.transform.rotation);
            cooldown = eggSpawnRate;
        }
    }
}
