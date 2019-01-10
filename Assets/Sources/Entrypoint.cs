using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrypoint : MonoBehaviour
{
    [SerializeField]
    private PlayfabManager _playfabManager;

    private bool _launchedScene;

    void Awake()
    {
        _launchedScene = false;
    }

    void Update()
    {
        if (!_launchedScene && _playfabManager.HasFinishedUpdate)
        {
            _launchedScene = true;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
