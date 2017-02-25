using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerTextController : MonoBehaviour
{

    private Text _text;

	// Use this for initialization
	void Start ()
    {
        _text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void UpdateText (int timeLeft)
    {
        _text.text = "Get Ready...\n" + timeLeft + "...\n";
    }
}
