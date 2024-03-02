using UnityEngine;
using TMPro;

public class UnderscoreChecker : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text resultText;

    private void Start()
    {
        // Attach a listener to the input field's OnValueChanged event
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string newValue)
    {
        // Check if the input contains underscores
        bool hasUnderscores = newValue.Contains("_");

        // Update the result text and color based on the presence of underscores
        if (hasUnderscores)
        {
            resultText.text = "Underscores(_) not allowed";
            resultText.color = Color.red;
        }
        else
        {
            resultText.text = "No Underscores(_) found";
            resultText.color = Color.green;
        }
    }
}
