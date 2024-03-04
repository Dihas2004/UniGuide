
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Events;

public class AuthenticationManager : MonoBehaviour
{
    public static AuthenticationManager Instance;

    public static UnityEvent OnSignInSuccess = new UnityEvent();
    public static UnityEvent<string> OnSignInFailed = new UnityEvent<string>();

    void Awake(){
        Instance = this;
    }

    public void SignIn (string username, string password){
        PlayFabClientAPI.LoginWithPlayFab (new LoginWithPlayFabRequest (){
            Username = username,
            Password = password,
        },
        response => {
            Debug.Log ($"SuccessFul Account Login: {username}");
            OnSignInSuccess.Invoke();
            SceneManager.LoadScene("Scenes/Main Menu");
        },
        error => {
           Debug.Log ($"UnsuccessFul Account Login: {username} \n {error.ErrorMessage}");
           OnSignInFailed.Invoke(error.ErrorMessage); 
        }
        );
    }
}



