using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_MainMenu : MonoBehaviour
{
    public void OnExitClicked()
    {
        Application.Quit();
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene( "Game" );
    }
}
