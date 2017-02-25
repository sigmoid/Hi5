using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {

    public float Sensitivity = 100;

    [HeaderAttribute("Shoulder Limits")]
    //Max and min rotation limits
    [SerializeField]
    private float s_MinRot;
    [SerializeField]
    private float s_MaxRot;

    private float s_CurrentRot = 0;

    [HeaderAttribute("Elbow Limits")]
    //Max and min rotation limits
    [SerializeField]
    private float e_MinRot;
    [SerializeField]
    private float e_MaxRot;

    private float e_CurrentRot = 0;

    [HeaderAttribute("Wrist Limits")]
    //Max and min rotation limits
    [SerializeField]
    private float w_MinRot;
    [SerializeField]
    private float w_MaxRot;

    private float w_CurrentRot = 0;

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
    {
        //Update all three joints
        UpdateAxis("Shoulder", s_MinRot, s_MaxRot, ref s_CurrentRot, UpperArm, _ShoulderAnchor);
        UpdateAxis("Elbow", e_MinRot, e_MaxRot, ref e_CurrentRot, ForeArm, _ElbowAnchor);
        UpdateAxis("Wrist", w_MinRot, w_MaxRot, ref w_CurrentRot, Hand, _WristAnchor);

        if (Input.GetAxis("Fire") != 0)
        {
            StartCoroutine(_Fiveage());
        }
    }

    private void UpdateAxis(string axis, float minLimit, float maxLimit, ref float currentRot, Transform obj, Transform anchor)
    {
        if (Input.GetAxis(axis) != 0)
        {
            float deg = Input.GetAxis(axis) * Time.deltaTime * Sensitivity;

            if (deg + currentRot <= maxLimit && deg + currentRot >= minLimit)
            {
                currentRot += deg;
                obj.RotateAround(anchor.position, Vector3.forward, deg);
            }
        }
    }

    private IEnumerator _Fiveage()
    {
        while (true)
        {
            float deg = Time.deltaTime * Sensitivity * 2;

            if (deg + e_CurrentRot <= e_MaxRot && deg + e_CurrentRot >= e_MinRot)
            {
                e_CurrentRot += deg;
                ForeArm.RotateAround(_ElbowAnchor.position, Vector3.forward, deg);
                yield return null;
            }
            else
            {
                yield break;
            }
        }
    }
}
