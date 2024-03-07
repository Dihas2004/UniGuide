using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptDisappear : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Start the coroutine to make the text disappear after 5 seconds
        StartCoroutine(DisappearAfterDelay(5f));
    }

    IEnumerator DisappearAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // After the delay, set the text to an empty string to make it disappear
        textMeshPro.text = "";
    }
}
