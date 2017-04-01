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

    }

    void OnCollisionEnter(Collision collision)
    {
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject gameManager = GameObject.Find("GameManager");
        GameController gameController = gameManager.GetComponent<GameController>();

        if (this.tag == "Palm" && other.tag == "Palm")
        {
            gameController.WinLevel();

            this.enabled = false;
        }

        else if (other.tag == "NotPalm")
        {
            gameController.LoseLevel();

            this.enabled = false;
        }
        else if (this.tag == "NotPalm" && other.tag == "NotPalm")
        {
            
            gameController.LoseLevel();

            this.enabled = false;
        }
    }
}
