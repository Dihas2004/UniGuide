using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{

    public void RegisterButtonClicked()
    {
        SceneManager.LoadScene("Scenes/Register");
    }

    public void LoginButtonClicked()
    {
        SceneManager.LoadScene("Scenes/Login");
    }

    public void NavigationButtonClicked()
    {
        SceneManager.LoadScene("Scenes/Nav - Ground Floor -1");
    }

   

}
