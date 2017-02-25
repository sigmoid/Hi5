using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZoomUI : MonoBehaviour {

    [SerializeField]
    private int AnimationTime;
    [SerializeField]
    private int maxScale;
    [SerializeField]
    private AnimationCurve curve;

    private RectTransform _image;
    private float _animTime;

	// Use this for initialization
	void Start ()
    { 
        _image = GetComponent<RectTransform>();
        _image.localScale = new Vector3(0, 0, 1);
        _animTime = 0;
	}

    // Update is called once per frame
    void Update()
    {
        _animTime += Time.deltaTime;

        float x = curve.Evaluate(_animTime / AnimationTime);

        _image.localScale = new Vector3(maxScale * x, maxScale * x, 1);
    }


}
