using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {

    [HeaderAttribute("Controls")]
    [SerializeField]
    private string _ShoulderAxis = "Shoulder";
    [SerializeField]
    private string _ElbowAxis = "Elbow";
    [SerializeField]
    private string _WristAxis = "Wrist";
    [SerializeField]
    private string _Hi5Axis = "Fire";

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
    public Transform _ShoulderAnchor, _ElbowAnchor, _WristAnchor;

    //Is the player currently doing an auto hi5
    private bool _IsFiving;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        if (!_IsFiving)
        {
            //Update all three joints

            //shoulder
            UpdateAxis(_ShoulderAxis, s_MinRot, s_MaxRot, ref s_CurrentRot, UpperArm, _ShoulderAnchor);
            //elbow
            UpdateAxis(_ElbowAxis, e_MinRot, e_MaxRot, ref e_CurrentRot, ForeArm, _ElbowAnchor);
            //wrist
            UpdateAxis(_WristAxis, w_MinRot, w_MaxRot, ref w_CurrentRot, Hand, _WristAnchor);
        }

        if (Input.GetAxis(_Hi5Axis) != 0)
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
        _IsFiving = true;
        while (true)
        {
            float deg = Time.deltaTime * Sensitivity * 2;

            if (deg + e_CurrentRot <= e_MaxRot && deg + e_CurrentRot >= e_MinRot )
            {
                e_CurrentRot += deg;
                ForeArm.RotateAround(_ElbowAnchor.position, Vector3.forward, deg);
                s_CurrentRot += deg;
                UpperArm.RotateAround(_ShoulderAnchor.position, Vector3.forward, deg);

                yield return null;
            }
            else
            {
                //Reached the end of the elbow range
                //TODO add fail state here
                _IsFiving = false;
                yield break;
            }
        }
    }
}
