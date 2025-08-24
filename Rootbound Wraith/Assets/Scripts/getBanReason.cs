using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class getBanReason : MonoBehaviour
{
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("You aren't banned how the hell did you get here?");
        SceneManager.LoadScene("Main"); // Replace with your main scene name
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Login error: " + error.Error);

        if (error.Error == PlayFabErrorCode.AccountBanned)
        {
            Debug.Log("You got banned");
            SceneManager.LoadScene("Bans"); // Replace with your banned scene name
        }
    }
}
