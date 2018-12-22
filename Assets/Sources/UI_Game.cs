using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Game : MonoBehaviour
{
    private const float cTime = 30f;

    private static readonly string[] _words = new []
    {
        "Elephant",
        "Tiger",
        "Monkey",
        "Bear",
        "Rabbit"
    };

    [SerializeField]
    private TextMeshProUGUI _timerLabel;
    [SerializeField]
    private TextMeshProUGUI _wordsGuessedLabel;
    [SerializeField]
    private TextMeshProUGUI _wordLabel;

    private int _wordsGuessed;
    private float _timeLast;
    private bool _finished;

    void Awake()
    {
        _timeLast = cTime;
        _finished = false;
        _wordsGuessedLabel.text = "0";
        ChangeWord();
    }

    void Update()
    {
        if (!_finished)
        {
            _timeLast -= Time.deltaTime;
            var timeLast = Mathf.RoundToInt( _timeLast );
            _timerLabel.text = timeLast.ToString();

            if (Input.GetKeyUp(KeyCode.W))
            {
                WordGuessed();
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                WordDiclined();
            }

            if (timeLast == 0)
            {
                _finished = true;
            }
        }
    }

    private void WordGuessed()
    {
        _wordsGuessed += 1;
        _wordsGuessedLabel.text = _wordsGuessed.ToString();
        ChangeWord();
    }

    private void WordDiclined()
    {
        ChangeWord();
    }

    private void ChangeWord()
    {
        _wordLabel.text = _words[Random.Range( 0, _words.Length )];
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
