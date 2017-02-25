using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class button_manager : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
