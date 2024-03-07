using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button scanButton; // Reference to the scan button
    public TextMeshProUGUI messageText; // Reference to the TextMeshPro element for the message

    void Start()
    {
        // Attach the method to be called when the button is clicked
        scanButton.onClick.AddListener(ShowMessage);
    }

    void ShowMessage()
    {
        // Display the message
        messageText.text = "Scan Surface and Tap on the scanned area";

        // Start a coroutine to hide the message after 5 seconds
        StartCoroutine(HideMessageAfterDelay(5f));
    }

    IEnumerator HideMessageAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // After the delay, set the message text to an empty string to hide it
        messageText.text = "";
    }
}
