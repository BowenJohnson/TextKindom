using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerKingdom _playerKingdom;
    [SerializeField] private TMP_InputField _inputText;
    [SerializeField] private TMP_Text _outputText;
    [SerializeField] private GameObject _enterButton;
    [SerializeField] private string _storedText;

    public void PushText(string text)
    {
        _outputText.text = "";
        _outputText.text = text;
    }

    public void GetTextButton()
    {
        _storedText = _inputText.text;
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
        _inputText.ActivateInputField();
        PromptNameYourKingdom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
