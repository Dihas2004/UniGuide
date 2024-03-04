using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Sign_up : MonoBehaviour
{

    [SerializeField]
    public TMP_Text errorText;
    // [SerializeField]
    // Text errorText;
    [SerializeField]
    Canvas canvas;
    string username, password, emailAddress;

    void OnEnable(){
        WriteText.OncreateAccountFailed.AddListener(OncreateAccountFailed);
        AuthenticationManager.OnSignInSuccess.RemoveListener(OnSignInSuccess);
    }
     void OnDisable(){
        WriteText.OncreateAccountFailed.RemoveListener(OncreateAccountFailed);
        AuthenticationManager.OnSignInSuccess.RemoveListener(OnSignInSuccess);
    }
    void OncreateAccountFailed(string error){
        errorText.text = error;
    }

    void OnSignInSuccess(){
      canvas.enabled = false;
    }

    public void UpdateUsername(string _username){
        username = _username;
    }
    public void UpdatePassword(string _password){
        password = _password;
    }
    public void UpdateEmailAddress(string _emailAddress){
        emailAddress = _emailAddress;
    }

    public void createAccount(){
        WriteText.Instance.createAccount(username,emailAddress,password);
    }
}
