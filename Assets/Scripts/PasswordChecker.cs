using UnityEngine;
using TMPro;

public class PasswordChecker : MonoBehaviour
{
    public TMP_InputField passwordField;
    public TMP_Text resultText;

    private void Start()
    {
        // Attach a listener to the input field's OnValueChanged event
        passwordField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string newValue)
    {
        // Check if the input contains at least 8 characters
        bool hasEnoughCharacters = newValue.Length >= 8;

        // Update the result text and color based on the presence of at least 8 characters
        if (!hasEnoughCharacters)
        {
            resultText.text = "Password must contain atleast 8 characters";
            resultText.color = Color.red;
        }
        else
        {
            resultText.text = "Password can be used";
            resultText.color = Color.green;
        }
    }
}