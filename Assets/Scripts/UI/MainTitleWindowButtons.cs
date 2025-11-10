using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTitleWindowButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
