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
        // Check if the input contains underscores or @ signs
        bool hasUnderscores = newValue.Contains("_");
        bool hasAtSigns = newValue.Contains("@");

        // Update the result text and color based on the presence of underscores or @ signs
        if (hasUnderscores || hasAtSigns)
        {
            resultText.text = "Underscores(_) or @ signs are not allowed";
            resultText.color = Color.red;
        }
        else
        {
            resultText.text = "No Underscores(_) or @ signs found";
            resultText.color = Color.green;
        }
    }
}