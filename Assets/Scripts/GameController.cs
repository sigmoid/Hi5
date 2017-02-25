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
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }

    void Start ()
    {
        endGameTimer.SetActive(false);
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
