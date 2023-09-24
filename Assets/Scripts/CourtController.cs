using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourtController : MonoBehaviour
{
    [SerializeField] private PlayerKingdom _playerKingdom;
    [SerializeField] private TMP_InputField _inputText;
    [SerializeField] private TMP_Text _outputText;
    [SerializeField] private GameObject _enterButton;
    [SerializeField] private string _storedText;
    public bool isActive { get; set; }

    private void Start()
    {
        _playerKingdom = _playerKingdom.GetComponent<PlayerKingdom>();
    }

    public void PushText(string text)
    {
        _outputText.text = "";
        _outputText.text = text;
    }

    public void GetTextButton()
    {
        _storedText = _inputText.text;
    }

    public void TargetInputTextBox()
    {
        _inputText.Select();
    }
}
