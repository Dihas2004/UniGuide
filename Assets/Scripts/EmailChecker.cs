using UnityEngine;
using TMPro;

public class EmailChecker : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_Text resultText;

    // Minimum number of characters required before allowing '@' sign
    private int minCharactersBeforeAtSign = 1;

    private void Start()
    {
        // Attach a listener to the input field's OnValueChanged event
        emailField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string newValue)
    {
        // Check if the input contains the '@' sign
        bool hasAtSign = newValue.Contains("@");

        // Check if the input length is less than the minimum characters before '@' sign
        bool inputLengthValid = newValue.Length >= minCharactersBeforeAtSign;

        // Check if the '@' sign is at the beginning of the input
        bool atSignAtBeginning = newValue.StartsWith("@");

        // Check if ".com" is present in the input
        bool hasDotCom = newValue.Contains(".com");

        // Check if there is at least one character between "@" and ".com"
        int atIndex = newValue.IndexOf("@");
        int dotComIndex = newValue.IndexOf(".com");
        bool hasCharacterBetweenAtAndDotCom = dotComIndex > atIndex + 1;

        // Update the result text and color based on the presence and position of '@' sign
        if (atSignAtBeginning && inputLengthValid)
        {
            resultText.text = "Email must not start with @ character";
            resultText.color = Color.red;
        }
        else if (!hasAtSign || !hasDotCom || !inputLengthValid || !hasCharacterBetweenAtAndDotCom)
        {
            resultText.text = "Email must contain '@' character, at least one character after '@', and '.com'";
            resultText.color = Color.red;
        }
        else
        {
            resultText.text = "Email format is correct";
            resultText.color = Color.green;
        }
    }
}