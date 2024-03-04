using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WriteText : MonoBehaviour{

    public static WriteText Instance;

    
    public static UnityEvent<string> OncreateAccountFailed = new UnityEvent<string>();

    void Awake(){
        Instance = this;
    }
    public void createAccount(string username, string emailAddress, string password){
        PlayFabClientAPI.RegisterPlayFabUser(
        new RegisterPlayFabUserRequest(){
            Email = emailAddress,
            Password = password,
            Username = username,
           // RequireBothUsernameAndEmail = true,
        },
        response =>{
            Debug.Log($"Successful Account Creation: {username},{emailAddress}");
            SceneManager.LoadScene("Scenes/Login");
        },
        error =>{
            Debug.Log($"Unsuccessful Account Creation: {username},{emailAddress} \n {error.ErrorMessage}");
            OncreateAccountFailed.Invoke(error.ErrorMessage);
        }
        );

    }
}