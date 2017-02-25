using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private int timeToNextLvl;

    [SerializeField]
    private GameObject[] winText;

    [SerializeField]
    private GameObject[] failText;

    [SerializeField]
    private GameObject endGameTimer;

    private TimerTextController _endGameTimerText;
    private double _endGameTimeLeft;
    private bool _levelOver;
    private bool _win;

    void Awake ()
    {
        // If we already have a game controller.
        if (instance != null && instance != this)
        {
            Destroy(this.transform.parent.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.transform.parent.gameObject);
        
    }

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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                else
                    RestartScene();
            }
        }
    }

    public void WinLevel ()
    {
        _win = true;
        EndLevel();

    }

    public void LoseLevel ()
    {
        _win = false;
        EndLevel();
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

        if (_win)
        {
            sel = Random.Range(0, winText.Length);
            text = Instantiate(winText[sel]);           
        }
        else
        {
            sel = Random.Range(0, failText.Length);
            text = Instantiate(failText[sel]);
        }

        text.transform.SetParent(this.transform);
        text.transform.position = new Vector3(transform.position.x, transform.position.y, 1);

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
