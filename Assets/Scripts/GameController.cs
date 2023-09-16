using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerKingdom _playerKingdom;
    [SerializeField] private GameObject _inputText;
    [SerializeField] private GameObject _outputText;
    [SerializeField] private GameObject _enterButton;
    private string storedText;

    public void PushText(string text)
    {
        _outputText.GetComponent<Text>().text = "";
        _outputText.GetComponent<Text>().text = text;
    }

    public void GetText()
    {
        storedText = _inputText.GetComponent<Text>().text;
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
        _playerKingdom.RenameKingdom(storedText);
    }

    // Start is called before the first frame update
    void Start()
    {
        PromptNameYourKingdom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}