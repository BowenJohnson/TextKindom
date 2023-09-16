using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerKingdom _playerKingdom;
    [SerializeField] private GameObject _inputText;
    [SerializeField] private GameObject _outputText;
    [SerializeField] private GameObject _enterButton;
    [SerializeField] private string _storedText;

    public void PushText(string text)
    {
        _outputText.GetComponent<TextMeshPro>().text = "";
        _outputText.GetComponent<TextMeshPro>().text = text;
    }

    public void GetText()
    {
        _storedText = _inputText.GetComponent<TextMeshPro>().text;
        PushText(_storedText);
    }
    private void PromptNameYourKingdom()
    {
        PushText("Name your Kingdom.");
    }

    public void NameYourKingdom()
    {
        bool playerReady = false;
        while (playerReady != true)
        {

        }
        _playerKingdom.RenameKingdom(_storedText);
    }

    // Start is called before the first frame update
    void Start()
    {
        //PromptNameYourKingdom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
