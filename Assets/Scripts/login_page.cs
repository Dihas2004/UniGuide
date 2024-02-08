using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField emailInputField;
    [SerializeField]
    private TMP_InputField passwordInputField;
    [SerializeField]
    private TextMeshProUGUI errorText;
    
    public void onClickLogin()
    {
        SceneManager.LoadScene(2);
    }

    public void onContinueLogin()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        

        string loginCheckMessage = checkLoginInfo(email,password);

        if (string.IsNullOrEmpty(loginCheckMessage))
        {
            //login
            Debug.Log("login");
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.LogError("ERROR : " + loginCheckMessage);
            errorText.text = "ERROR : " + loginCheckMessage;
        }
    }

    private string checkLoginInfo(string email,string password)
    {
        string returnString = "";

        if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password) )
        {
            returnString = "Both email and password are empty";
        }
        else if (string.IsNullOrEmpty(email))
        {
            returnString = "Email was empty";
        }
        else if (string.IsNullOrEmpty(password))
        {
            returnString = "Password was empty";
        }
        else
        {
            returnString = "";
        }

        
        return returnString;
    }

    public void removeErrorText()
    {
        errorText.text = "";
    }
}