using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewGameController : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private PlayerKingdom _playerKingdom;
    [SerializeField] private TMP_InputField _inputText;
    [SerializeField] private TMP_Text _outputText;
    [SerializeField] private GameObject _enterButton;
    private const int _nameCharLimit = 11;

    private void Start()
    {
        _gameController = _gameController.GetComponent<GameController>();
        _playerKingdom = _playerKingdom.GetComponent<PlayerKingdom>();
        _inputText.characterLimit = _nameCharLimit;
        _inputText.Select();
    }

    public void GetTextButton()
    {
        _playerKingdom.RenameKingdom(_inputText.text);
        _gameController.NewGameEnd();
    }

    public void PushText(string text)
    {
        _outputText.text = "";
        _outputText.text = text;
    }

    public void TargetInputTextBox()
    {
        _inputText.Select();
    }
}
