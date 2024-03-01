using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Sign_up : MonoBehaviour
{
    string username, password, emailAddress;

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
