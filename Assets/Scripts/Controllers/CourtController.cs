using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class CourtController : MonoBehaviour
{
    [SerializeField] private PlayerKingdom _playerKingdom;
    [SerializeField] private TMP_InputField _inputText;
    [SerializeField] private TMP_Text _outputText;
    [SerializeField] private GameObject _enterButton;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private string _storedText;
    public bool isActive { get; set; }

    [Header("Ink JSON")]
    [SerializeField] private TextAsset _inkJSON;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private GameObject _continueDialogueButton;

    private Story _currentStory;

    private bool _dialogueIsPlaying;

    private void Start()
    {
        _playerKingdom = _playerKingdom.GetComponent<PlayerKingdom>();
        _dialogueIsPlaying = false;
        _dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        // return right away if dialogue isn't playing
        if (!_dialogueIsPlaying)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
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

    public void StartDialogue()
    {
        // Debug.Log(_inkJSON.text);

        _currentStory = new Story(_inkJSON.text);
        _dialogueIsPlaying = true;
        _dialoguePanel.SetActive(true);
        _continueDialogueButton.SetActive(true);
        _nextButton.SetActive(false);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        _dialogueIsPlaying = false;
        _continueDialogueButton.SetActive(false);
        _dialoguePanel.SetActive(false);
        _dialogueText.text = "";
        _nextButton.SetActive(true);
    }

    public void ContinueStory()
    {
        // if the story can continue then keep going else exit dialogue
        if (_currentStory.canContinue)
        {
            _dialogueText.text = _currentStory.Continue();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
}
