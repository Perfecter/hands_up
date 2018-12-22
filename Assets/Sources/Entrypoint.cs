using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrypoint : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene( "MainMenu" );
    }
}
