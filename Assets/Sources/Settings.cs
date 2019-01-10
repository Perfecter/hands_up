using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public const int cDefaultTime = 30;

    private const int cMinTime = 10;

    [SerializeField]
    private InputField _input;

    void Awake()
    {
        _input.text = PlayerPrefs.GetInt("Timer", cDefaultTime).ToString();
    }

    public void OnEndEdit(string input)
    {
        Debug.Log("Changed");
        if (float.TryParse(input, out float value))
        {
            var newValue = Mathf.RoundToInt(Mathf.Max(cMinTime, value));

            PlayerPrefs.SetInt("Timer", newValue);
        }
    }

    public void OnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
