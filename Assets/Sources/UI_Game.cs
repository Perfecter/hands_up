using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Game : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerLabel;
    [SerializeField]
    private TextMeshProUGUI _wordsGuessedLabel;
    [SerializeField]
    private TextMeshProUGUI _wordLabel;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private GameObject _resultsView;

    [SerializeField]
    private TextMeshProUGUI _resultsLabel;

    void Awake()
    {
        _gameManager.OnTimeFinished += HandleTimeFinished;
    }

    void OnDestroy()
    {
        if (_gameManager != null)
        {
            _gameManager.OnTimeFinished -= HandleTimeFinished;
        }
    }

    private void HandleTimeFinished()
    {
        _resultsLabel.text = _gameManager.WordsGuessed.ToString();
        _resultsView.SetActive(true);
    }

    void Update()
    {
        var timeLast = Mathf.RoundToInt(_gameManager.TimeLast);

        _timerLabel.text = timeLast.ToString();

        _wordsGuessedLabel.text = _gameManager.WordsGuessed.ToString();
        _wordLabel.text = _gameManager.CurrentWord;
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene( "MainMenu" );
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
