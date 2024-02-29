using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using TMPro;
using UnityEngine.SceneManagement;

 
    

public class WriteText : MonoBehaviour
{
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;

    [SerializeField]
    public TMP_InputField firstNameRegisterField;
    [SerializeField]
    public TMP_InputField lastNameRegisterField;
    [SerializeField]
    public TMP_InputField emailRegisterField;
    [SerializeField]
    public TMP_InputField passwordRegisterField;
    [SerializeField]
    public TMP_InputField confirmPasswordRegisterField;

    private void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            Firebase.DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                    "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

     void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;

            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);  
            }
        }
    }

    public void Register()
    {
        StartCoroutine(RegisterAsync(firstNameRegisterField.text,lastNameRegisterField.text,emailRegisterField.text,passwordRegisterField.text,confirmPasswordRegisterField.text));
    }
    private IEnumerator RegisterAsync(string firstName,string lastName,string email,string password,string confirmPassword)
    {
        if (firstName == " ")
        {
            Debug.LogError("First name is empty");
        }
        else if (lastName == " ")
        {
            Debug.LogError("last name is empty");
        }
        else if (email == " ")
        {
            Debug.LogError("email is empty");
        }
        else if (password == " ")
        {
            Debug.LogError("password is empty");
        }
        else if (confirmPassword == " ")
        {
            Debug.LogError("confirm password is empty");
        }
        else if (passwordRegisterField.text != confirmPasswordRegisterField.text)
        {
            Debug.LogError("password does not match");
        }
        else
        {
            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email,password);
            yield return new WaitUntil(() => registerTask.IsCompleted);
            if (registerTask.Exception != null)
            {
                Debug.LogError(registerTask.Exception);

                FirebaseException firebaseException = registerTask.Exception.GetBaseException() as FirebaseException;
                AuthError authError = (AuthError)firebaseException.ErrorCode;

                string failedMessage = "Register Failed! Because ";
                switch (authError)
                {
                    case AuthError.InvalidEmail:
                        failedMessage += "Email is invalid";
                        break;
                    case AuthError.WrongPassword:
                        failedMessage += "Wrong Password";
                        break;
                    case AuthError.MissingEmail:
                        failedMessage += "Email is missing";
                        break;
                    case AuthError.MissingPassword:
                        failedMessage += "Password is missing";
                        break;
                    default:
                        failedMessage += "Registration failed";
                        break;
                }
                Debug.Log(failedMessage);
            }
            else
            {
                AuthResult authResult = registerTask.Result;
                user = authResult.User;
                

                UserProfile userProfile = new UserProfile {DisplayName = firstName + lastName};

                var updateProfileTask = user.UpdateUserProfileAsync(userProfile);

                yield return new WaitUntil(() => updateProfileTask.IsCompleted);

                if (updateProfileTask.Exception != null)
                {
                    user.DeleteAsync();
                    Debug.LogError(updateProfileTask.Exception);
                    FirebaseException firebaseException = updateProfileTask.Exception.GetBaseException() as FirebaseException;
                    AuthError authError = (AuthError)firebaseException.ErrorCode;

                    string failedMessage = "Profile update Failed! Because ";
                    switch (authError)
                    {
                        case AuthError.InvalidEmail:
                            failedMessage += "Email is invalid";
                            break;
                        case AuthError.WrongPassword:
                            failedMessage += "Wrong Password";
                            break;
                        case AuthError.MissingEmail:
                            failedMessage += "Email is missing";
                            break;
                        case AuthError.MissingPassword:
                            failedMessage += "Password is missing";
                            break;
                        default:
                            failedMessage += "Profile update failed";
                            break;
                    }
                    Debug.Log(failedMessage);
                }
                else
                {
                    Debug.Log("Registration Sucessful Welcome " + user.DisplayName);
                    SceneManager.LoadScene("Scenes/Login");
                }
            }
        }
    }
}