
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using PlayFab;
using PlayFab.ClientModels;

public class AuthenticationManager : MonoBehaviour
{
    public static AuthenticationManager Instance;

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
            SceneManager.LoadScene("Scenes/Main Menu");
        },
        error => {
           Debug.Log ($"UnsuccessFul Account Login: {username} \n {error.ErrorMessage}"); 
        }
        );
    }
}



