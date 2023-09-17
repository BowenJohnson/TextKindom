using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this function will listen for the press of the return key and activate the UI enter button
public class EnterKeyInput : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    // Update is called once per frame
    void Update()
    {
        // if retrun key was pressed call UI "Enter Button" function
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _gameController.GetTextButton();
        }
    }
}
