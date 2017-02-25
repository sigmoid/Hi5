using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {


    public Transform UpperArm, ForeArm, Hand;
    private Transform _ShoulderAnchor, _ElbowAnchor, _WristAnchor;

	// Use this for initialization
	void Start () {
        _ShoulderAnchor = GameObject.Find("ShoulderAnchor").transform;
        _ElbowAnchor = GameObject.Find("ElbowAnchor").transform;
        _WristAnchor = GameObject.Find("WristAnchor").transform;
    }
	
	// Update is called once per frame
	void Update () 

	}
}
