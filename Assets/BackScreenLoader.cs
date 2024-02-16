using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScreenLoader : MonoBehaviour

{
    // Method to handle back button click
    public void GoBack()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex; // Get current scene index

        // Check if current scene is not the first scene
        if (currentIndex > 0)
        {
            SceneManager.LoadScene(currentIndex - 1); // Load previous scene
        }
        else
        {
            Debug.LogWarning("No previous scene available.");
        }
    }
}
