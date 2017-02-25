using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZoomUI : MonoBehaviour {

    [SerializeField]
    private int maxScale;

    private RectTransform _image;

	// Use this for initialization
	void Start ()
    { 
        _image = GetComponent<RectTransform>();
        _image.localScale = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = _image.localScale.x;
        float y = _image.localScale.y;

        if (_image.localScale.x <= maxScale)
            _image.localScale += new Vector3(.5f, .5f, 0);
	}


}
