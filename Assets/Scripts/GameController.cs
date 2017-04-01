using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{ 
    [SerializeField]
    private int timeToNextLvl;

    [SerializeField]
    private GameObject[] winText;

    [SerializeField]
    private GameObject[] failText;

    [SerializeField]
    private GameObject[] failTimeText;

    [SerializeField]
    private GameObject endGameTimer;

    [SerializeField]
    private string[] levels;
    private static List<int> shuffled;
    

    private TimerTextController _endGameTimerText;
    private double _endGameTimeLeft;
    private bool _levelOver;
    private bool _win;

    
  

    // Start
    void Start ()
    {
        endGameTimer.SetActive(false);
        _win = false;
        _levelOver = false;
        _endGameTimerText = endGameTimer.GetComponent<TimerTextController>();
        
    }

    void Update ()
    {  
        if (_levelOver)
        {
            _endGameTimeLeft -= Time.deltaTime;
            endGameTimer.SetActive(true);
            _endGameTimerText.UpdateText((int)_endGameTimeLeft);

            if (_endGameTimeLeft <= 0)
            {
            
                if (_win)
                {   
                    if (shuffled == null)
                    {
                        shuffled = new List<int>();
                        for (int i = 1; i < levels.Length; i++)
                            shuffled.Add(i);
                    }                            
                    int sel = Random.Range(0, shuffled.Count);
                    int toLoad = shuffled[sel];
                    
                    shuffled.RemoveAt(sel);
                    if (shuffled.Count == 0)
                    {
                        for (int i = 0; i < levels.Length; i++)
                        {
                            shuffled.Add(i);
                        }
                        shuffled.Remove(toLoad);
                    }
                    SceneManager.LoadScene(levels[toLoad]);

                }
                else
                {
                    RestartScene();
                }
            }
        }
    }

    public void WinLevel ()
    {
        _win = true;

        // Display text
        GameObject text;
        int sel;

        // Stop moving
        GameObject.Find("Arm").GetComponent<ArmController>().enabled = false;

        // Stop level timer
        GameObject.Find("LevelTimer").GetComponent<LevelTimerController>().enabled = false;

        if (_win && !_levelOver)
        {
            sel = Random.Range(0, winText.Length);
            text = Instantiate(winText[sel]);
            text.transform.SetParent(this.transform);
            text.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }    

        // Begin timer for next stage
        _levelOver = true;
        _endGameTimeLeft = timeToNextLvl;
        endGameTimer.SetActive(true);

    }

    public void LoseLevel ()
    {
        _win = false;

        // Display text
        GameObject text;
        int sel;

        // Stop moving
        GameObject.Find("Arm").GetComponent<ArmController>().enabled = false;

        // Stop level timer
        GameObject.Find("LevelTimer").GetComponent<LevelTimerController>().enabled = false;


        if (!_levelOver)
        {
            sel = Random.Range(0, failText.Length);
            text = Instantiate(failText[sel]);
            text.transform.SetParent(this.transform);
            text.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }

        // Begin timer for next stage
        _levelOver = true;
        _endGameTimeLeft = timeToNextLvl;
        endGameTimer.SetActive(true);

    }

    public void TimeUp ()
    {
        _win = false;

        // Display text
        GameObject text;
        int sel;

        // Stop moving
        GameObject.Find("Arm").GetComponent<ArmController>().enabled = false;

        // Stop level timer
        GameObject.Find("LevelTimer").GetComponent<LevelTimerController>().enabled = false;

        if (!_levelOver)
        {
            sel = Random.Range(0, failTimeText.Length);
            text = Instantiate(failTimeText[sel]);
            text.transform.SetParent(this.transform);
            text.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }


        // Begin timer for next stage
        _levelOver = true;
        _endGameTimeLeft = timeToNextLvl;
        endGameTimer.SetActive(true);
    }

    private void EndLevel ()
    {
        // Display text
        GameObject text;
        int sel;

        // Stop moving
        GameObject.Find("Arm").GetComponent<ArmController>().enabled = false;

        // Stop level timer
        GameObject.Find("LevelTimer").GetComponent<LevelTimerController>().enabled = false;

        if (_win && !_levelOver)
        {
            sel = Random.Range(0, winText.Length);
            text = Instantiate(winText[sel]);
            text.transform.SetParent(this.transform);
            text.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else if (!_levelOver)
        {
            sel = Random.Range(0, failText.Length);
            text = Instantiate(failText[sel]);
            text.transform.SetParent(this.transform);
            text.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }


        // Begin timer for next stage
        _levelOver = true;
        _endGameTimeLeft = timeToNextLvl;
        endGameTimer.SetActive(true);

    }

    public void RestartScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
