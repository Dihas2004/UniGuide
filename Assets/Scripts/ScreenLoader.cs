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

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }

    public void GoToSignUp()
    {
        SceneManager.LoadScene("Scenes/Register");
    }

    public void GoToLogIn()
    {
        SceneManager.LoadScene("Scenes/Login");
    }

    public void GoToLHomePage()
    {
        SceneManager.LoadScene("Scenes/home page");
    }

    public void GoTo3DLayout()
    {
        SceneManager.LoadScene("Scenes/3D Layout");
    }

    public void GoToNavList()
    {
        SceneManager.LoadScene("Scenes/Navigation List");
    }

    public void GoToNavFloorGround()
    {
        SceneManager.LoadScene("Scenes/Nav - Ground Floor -1");
    }
    public void GoToNavFloor1()
    {
        SceneManager.LoadScene("Scenes/Nav - 1st Floor");
    }

    public void GoToNavFloor2()
    {
        SceneManager.LoadScene("Scenes/Nav - 2nd floor");
    }

    public void GoToNavFloor3()
    {
        SceneManager.LoadScene("Scenes/Nav- 3rd floor");
    }

    public void GoToNavFloor4()
    {
        SceneManager.LoadScene("Scenes/Nav-4th floor");
    }

}
