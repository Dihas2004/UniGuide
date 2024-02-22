
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class AuthenticationManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField emailInputField;
    [SerializeField]
    private TMP_InputField passwordInputField;
   
    
    [SerializeField]
    private TextMeshProUGUI errorText;
    
    // File path to store sign-up information
    private string filePath;

    private string folderName = "TextFiles";
    private string fileName = "append.txt";

    private void Start()
    {
        // Set the file path where sign-up information will be stored
        filePath = Path.Combine(Application.dataPath, folderName, fileName);

        Debug.Log("File path: " + Application.persistentDataPath);

    }

    public void onClickLogin()
    {
        SceneManager.LoadScene("Scenes/Login");
    }
    public void onClickSignup()
    {
        SceneManager.LoadScene("Scenes/Register");
    }

    
    public void onContinueLogin()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Check if login credentials match sign-up information
        if (CheckLoginCredentials(email, password))
        {
            Debug.Log("Login successful");
            SceneManager.LoadScene("Scenes/Main Menu");
        }
        else
        {
            Debug.LogError("Login failed: Invalid credentials");
            errorText.text = "Login failed: Invalid credentials";
        }
    }

    private bool CheckLoginCredentials(string email, string password)
{
    // Read sign-up information from file
    string[] lines = File.ReadAllLines(filePath);

    // Iterate over the lines in pairs (email and password)
    for (int i = 2; i < lines.Length; i += 2)
    {
        // Extract email and password from the current pair of lines
        string storedEmail = lines[i].Trim();
        string storedPassword = lines[i + 1].Trim();

        // Check if the provided email and password match the stored values
        if (email == storedEmail && password == storedPassword)
        {
            return true; // Credentials match
        }
    }

    return false; // No matching credentials found
}



    public void removeErrorText()
    {
        errorText.text = "";
    }
}



