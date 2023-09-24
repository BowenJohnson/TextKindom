using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this function will listen for the press of the return key and activate the UI enter button
public class EnterKeyInput : MonoBehaviour
{
    [SerializeField] private CourtController _courtController;

    private void Start()
    {
        _courtController = _courtController.GetComponent<CourtController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if retrun key was pressed and court menu is active call UI "Enter Button" function
        if (Input.GetKeyDown(KeyCode.Return) && _courtController.isActive == true)
        {
            _courtController.GetTextButton();
            _courtController.TargetInputTextBox();
        }
    }
}
