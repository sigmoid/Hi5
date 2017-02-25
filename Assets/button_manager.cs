using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class button_manager : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Level1");
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
