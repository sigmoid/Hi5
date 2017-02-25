using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public bool UpDown;
    public int upRange;
    public int downRange;
    public float speed = 0.01f;

    private bool goingUp;

	// Use this for initialization
	void Start () {
        if (UpDown)
            goingUp = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (UpDown)
        {
            if (goingUp)
            {
                if (this.transform.position.y < upRange)
                    goingUp = false;
                else
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);
            }
            else
            {
                if (this.transform.position.y > downRange)
                    goingUp = true;
                else
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed, this.transform.position.z);
            }
        }
	}
}
