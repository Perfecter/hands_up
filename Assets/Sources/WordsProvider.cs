using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsProvider
{
    private class WordsJsonModel
    {
        public string[] Words;
    }

    private static readonly string[] cDefaultWords = new[]
    {
        "Elephant",
        "Tiger",
        "Monkey",
        "Bear",
        "Rabbit"
    };

    private static WordsProvider _instance;

    public static WordsProvider Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WordsProvider();
            }
            return _instance;
        }
    }

    public string[] Words { get; private set; }

    private WordsProvider()
    {
        var wordsJson = PlayerPrefs.GetString("Words","");

        if (!string.IsNullOrEmpty(wordsJson))
        {
            var wordsObject = JsonUtility.FromJson<WordsJsonModel>(wordsJson);

            Words = wordsObject.Words;
        }
        else
        {
            Words = cDefaultWords;
        }
    }
}
