using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private const float cTime = 30f;

    

    public event Action OnTimeFinished;

    public int WordsGuessed { get; private set; }
    public float TimeLast { get; private set; }
    public string CurrentWord { get; private set; }

    private List<string> _availableWords = new List<string>();

    private bool _finished;

    void Awake()
    {
        TimeLast = cTime;
        _finished = false;

        ChangeWord();
    }

    void Update()
    {
        if (!_finished)
        {
            TimeLast -= Time.deltaTime;
            var timeLast = Mathf.RoundToInt(TimeLast);

            if (timeLast == 0)
            {
                _finished = true;

                if (OnTimeFinished != null)
                {
                    OnTimeFinished();
                }
            }
        }
    }

    public void WordGuessed()
    {
        WordsGuessed += 1;
        ChangeWord();
    }

    public void WordDiclined()
    {
        ChangeWord();
    }

    private void ChangeWord()
    {
        CurrentWord = GetNewWord();
    }

    private string GetNewWord()
    {
        if (_availableWords.Count == 0)
        {
            _availableWords = WordsProvider.Instance.Words.ToList();
        }

        var randomIndex = Random.Range(0, _availableWords.Count);

        var word = _availableWords[randomIndex];

        _availableWords.RemoveAt(randomIndex);

        return word;
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
