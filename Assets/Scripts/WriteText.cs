using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WriteText : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> txtInputs;// Use a list for multiple input fields
    private string folderName = "TextFiles";
    private string fileName = "append.txt";
    private string appendFile;
    

    // Start is called before the first frame update
    void Start()
    {
        appendFile = Path.Combine(Application.dataPath, folderName, fileName);
    }

    // Update is called once per frame

    public void AppendText()
    {
        foreach (var txtInput in txtInputs)
        {
            if (!File.Exists(appendFile))
            {
                File.WriteAllText(appendFile, txtInput.text);
            }
            else
            {
                using (var writer = new StreamWriter(appendFile, true))
                {
                    writer.WriteLine(txtInput.text);
                }
            }
        }
    }
}