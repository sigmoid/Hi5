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
    private GameObject TimerText;

    private TimerTextController _timerTextScript;
    private double _timeLeft;
    private bool _levelOver;

    void Awake ()
    {
        // If we already have a game controller.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }

    void Start ()
    {
        TimerText.SetActive(false);
        _levelOver = false;
        _timerTextScript = TimerText.GetComponent<TimerTextController>();
        EndLevel(true);
    }

    void Update ()
    {  
        if (_levelOver)
        {
            _timeLeft -= Time.deltaTime;
            TimerText.SetActive(true);
            _timerTextScript.UpdateText((int)_timeLeft);

            if (_timeLeft <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void WinLevel ()
    {
        EndLevel(true);
    }

    public void LoseLevel ()
    {
        EndLevel(false);
    }

    private void EndLevel (bool win)
    {
        // Display text
        GameObject text;
        int sel;

        if (win)
        {
            sel = Random.Range(0, winText.Length);
            //text = Instantiate(winText[sel]);
        }
        else
        {
            sel = Random.Range(0, failText.Length);
            //text = Instantiate(failText[sel]);
        }

        //text.transform.position = new Vector3(40, 50);

        // Begin timer for next stage
        _levelOver = true;
        _timeLeft = timeToNextLvl;
        TimerText.SetActive(true);

    }

    public void RestartScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
