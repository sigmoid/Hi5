using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    private bool _start;
	// Use this for initialization
	void Start () {
        _start = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!_start)
        {
            GetComponent<Animator>().StartPlayback();
            _start = true;
        }
	}
}
