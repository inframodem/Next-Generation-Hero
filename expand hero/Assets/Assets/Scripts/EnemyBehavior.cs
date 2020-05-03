using UnityEngine;
using System.Collections;
using System.Threading;


public class EnemyBehavior : MonoBehaviour {

	public enum Checkpointname { A = 0, B , C, D, E, F }
	public Checkpointname currcheck;
	public float mSpeed = 20f;
	public bool isSequence = true;
	public GameObject target;
	public GameObject[] checkobj = new GameObject[6];
	public Vector3 home;
	
	// Use this for initialization
	void Start () {
		target = checkobj[(int)currcheck];
		home = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		//toggles if the enemy moves in sequence
		if (Input.GetKeyDown(KeyCode.J))
        {
			isSequence = !isSequence;
        }
		//enemy moves toward target
		transform.position = Vector2.MoveTowards(transform.position,target.transform.position, 2.0f * Time.deltaTime);
		Vector2 dir = target.transform.position - transform.position;
		//orientates enemy to target
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
		//if enmey is within 1 unity uniy of the target change target to the next one
		if (Vector3.Distance(target.transform.position, transform.position) <= 1f)
        {
			changetarget();
        }
	}
	private void changetarget()
	{
		//change next target based on if its in sequence or not
		if (isSequence)
		{
			switch (currcheck)
			{
				case Checkpointname.A:
					currcheck = Checkpointname.B;
					target = checkobj[1];
					break;
				case Checkpointname.B:
					currcheck = Checkpointname.C;
					target = checkobj[2];
					break;
				case Checkpointname.C:
					currcheck = Checkpointname.D;
					target = checkobj[3];
					break;
				case Checkpointname.D:
					currcheck = Checkpointname.E;
					target = checkobj[4];
					break;
				case Checkpointname.E:
					currcheck = Checkpointname.F;
					target = checkobj[5];
					break;
				case Checkpointname.F:
					currcheck = Checkpointname.A;
					target = checkobj[0];
					break;
			}
		}
        else
        {
			//get random number and make target that random number
			int randtarg = Random.Range(0, 5);
			target = checkobj[randtarg];
			currcheck = (Checkpointname)randtarg;
        }
    }
	public void respawn()
    {
		transform.position = home;
    }
}
