using UnityEngine;
using System.Collections;

public class LevelTimerController : MonoBehaviour {

    public float levelTime = 15;

    private Vector3 totalScale;
    private float _levelTimeLeft;

    // Use this for initialization
    void Start () {
        _levelTimeLeft = levelTime;
        totalScale = this.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        if (_levelTimeLeft > 0)
        {
            _levelTimeLeft -= Time.deltaTime;
            this.transform.localScale = new Vector3(totalScale.x * (_levelTimeLeft / levelTime), totalScale.y, totalScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(0, totalScale.y, totalScale.z);
        }

        if (_levelTimeLeft <= 0)
            GameObject.Find("GameManager").GetComponent<GameController>().TimeUp();
        
	}
}
