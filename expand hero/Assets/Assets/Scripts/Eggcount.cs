using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Eggcount : MonoBehaviour
{
    public Text countdis;
    public int count;
    public int entitiesTouched;
    public EnemyBehavior isSequence;
    public int enemiesKilled;
    public bool ismouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void forceaddegg()
    {
        count++;
    }
    // Update is called once per frame
    void Update()
    {
        //record ui information
        string waymode = "";
        string heromode = "";
        if (!isSequence.isSequence)
        {
            waymode = "Random";
        }
        else
            waymode = "Sequence";
        if (!ismouse)
        {
            heromode = "Key";
        }
        else
            heromode = "Mouse";

        countdis.text = "WAYPOINT:(" + waymode + ") HERO: Drive(" + heromode + ") TouchedEnemy(" + entitiesTouched +
            ") EnemiesKiller(" + enemiesKilled + ") EGG: OnScreen(" + count + ")";
    }
}
