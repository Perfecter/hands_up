using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabManager : MonoBehaviour
{
    public bool HasFinishedUpdate;

    void Awake()
    {
        HasFinishedUpdate = false;

        PlayFabSettings.TitleId = "E40C";

        var request = new LoginWithAndroidDeviceIDRequest
        {
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithAndroidDeviceID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        ClientGetTitleData();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        FinishUpdate();
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    public void ClientGetTitleData()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(),
            result =>
            {
                if (result.Data != null)
                {
                    var wordsJson = result.Data["Words"];
                    Debug.Log(wordsJson);
                    PlayerPrefs.SetString("Words", wordsJson);
                    FinishUpdate();
                }
                else
                {
                    FinishUpdate();
                }
            },
            error =>
            {
                FinishUpdate();
                Debug.Log("Got error getting titleData:");
                Debug.Log(error.GenerateErrorReport());
            }
        );
    }

    private void FinishUpdate()
    {
        HasFinishedUpdate = true;
    }
}
