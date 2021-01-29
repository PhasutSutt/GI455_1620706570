using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplicationSearching : MonoBehaviour
{
    string[] textForSearching = { "unity", "unreal", "residentEvil", "google", "mongoDB" };
    public Text Keyword, FoundText;
    string inputWord;
    public GameObject InputField;
    void Start()
    {
            Keyword.text = textForSearching[0] + "\r\n" +
                textForSearching[1] + "\r\n" +
                textForSearching[2] + "\r\n" +
                textForSearching[3] + "\r\n" +
                textForSearching[4] + "\r\n";
    }

    public void Find()
    {
        inputWord = InputField.GetComponent<Text>().text;

        for (int j = 0; j<textForSearching.Length; j++)
        {
            if (inputWord == textForSearching[j])
            {
                FoundText.color = Color.green;
                FoundText.text = " [ " +  inputWord + " ] is found";
                return;
            }
            else
            {
                FoundText.color = Color.red;
                FoundText.text = " [ " + inputWord + " ] isn't found";
            }
        }
        

    }
}
