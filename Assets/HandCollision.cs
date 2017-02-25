using UnityEngine;
using System.Collections;

public class HandCollision : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print("seeck hi5");
    }

    void OnCollisionEnter(Collision collision)
    {
        //print("collision: STOP IT");
    }

    void OnTriggerEnter(Collider other)
    {
        //print("trigger: seeck hi5");

        if (other.tag == "Palm")
        {
            print("SICK HYFYVE");
            Destroy(other.transform.parent.gameObject);
        }
        else if (other.tag == "NotPalm")
            print("THAT WAS NOT A HYFYVE");
    }
}
