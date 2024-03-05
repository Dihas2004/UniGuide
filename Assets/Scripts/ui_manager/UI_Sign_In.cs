using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Sign_In : MonoBehaviour
{
    [SerializeField]
    public TMP_Text errorText;

    [SerializeField]
    public TMP_Text welcomeText;
   
    [SerializeField]
    Canvas canvas;
    string username, password ;

    void OnEnable(){
        AuthenticationManager.OnSignInFailed.AddListener(OnSignInFailed);
        AuthenticationManager.OnSignInSuccess.RemoveListener(OnSignInSuccess);

    }
    void OnDisable(){
        AuthenticationManager.OnSignInFailed.RemoveListener(OnSignInFailed);
        AuthenticationManager.OnSignInSuccess.RemoveListener(OnSignInSuccess);
    }
    void OnSignInFailed(string error){
        errorText.gameObject.SetActive(true);
        errorText.text = error;
    }
    void OnSignInSuccess(){
        canvas.enabled = false;
        welcomeText.text = "Welcome to uniguide, " + username; // Display welcome message with username
        welcomeText.gameObject.SetActive(true);
    }

    public void UpdateUsername(string _username){
        username = _username;
    }
    public void UpdatePassword(string _password){
        password = _password;
    }

    public void SignIn(){
        AuthenticationManager.Instance.SignIn(username,password);
    }
}
