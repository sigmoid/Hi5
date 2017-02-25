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
        GameObject gameManager = GameObject.Find("GameManager");
        GameController gameController = gameManager.GetComponent<GameController>();

        if (this.tag == "Palm" && other.tag == "Palm")
        {
            print("THAT WAS A GUD HYFYVE");

            gameController.WinLevel();

            this.enabled = false;
        }
        else if (other.tag == "NotPalm")
        {
            print("THAT WAS NOT A HYFYVE");

            gameController.LoseLevel();

            this.enabled = false;
        }
    }
}
