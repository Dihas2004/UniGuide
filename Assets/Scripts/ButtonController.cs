using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public List<TMP_InputField> inputFields; // Reference to your input fields
    public Button submitButton; // Reference to your submit button
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;
    public TextMeshProUGUI messageText;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, disable the button
        submitButton.interactable = false;

        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all input fields are filled
        bool allFieldsFilled = CheckAllFieldsFilled() && CheckPasswordsMatch();

        // Enable or disable the button based on the check
        submitButton.interactable = allFieldsFilled;
    }

    bool CheckAllFieldsFilled()
    {
        foreach (var inputField in inputFields)
        {
            // Check if the text of the input field is empty
            if (string.IsNullOrEmpty(inputField.text))
            {
                return false; // Return false if any field is empty
            }
        }

        return true; // All fields are filled
    }

    bool CheckPasswordsMatch()
    {
        // Check if password and confirm password match
        return passwordInput.text == confirmPasswordInput.text;
    }

    void OnSubmitButtonClick()
    {
        // Check if the passwords match before proceeding
        if (CheckPasswordsMatch())
        {
            // Account created successfully, update the UI Text
            messageText.text = "Account created successfully!";
        }
        else
        {
            // Passwords don't match, update the UI Text with an error message
            messageText.text = "Passwords do not match. Please try again.";
        }

        // You might want to reset the message after a certain time or after the user takes another action
        StartCoroutine(ResetMessageAfterDelay(3.0f));
    }

    // Optional: Coroutine to reset the message after a delay
    private IEnumerator ResetMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.text = "";
    }
}