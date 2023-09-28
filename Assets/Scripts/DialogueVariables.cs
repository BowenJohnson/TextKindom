using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;
using System;

public class DialogueVariables
{
    private PlayerKingdom _playerKingdom;
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    public DialogueVariables(string globalsFilePath, PlayerKingdom playerKingdom)
    {
        _playerKingdom = playerKingdom;

        // compile the story
        string inkFileContents = File.ReadAllText(globalsFilePath);
        Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        Story globalVariableStory = compiler.Compile();

        // initialize the dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();

        foreach(string name in globalVariableStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariableStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initialized global dialogue variable " + name + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        // VariablesToStory needs to happen before assigning the listener
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        // only maintain variables that were initialized from the globals ink file
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
            UpdateKingdomStats();
        }
    }

    private void KingdomVarsToStory()
    {

        // TODO: need to figure out how to convert int into ink runtime...
        Ink.Runtime.Object value = new Ink.Runtime.Object();
        Ink.Runtime.IntValue input = new IntValue();
        int gold = _playerKingdom.GetGold();

        //int someInt = (Ink.Runtime.IntValue)value;
        
        //value = (IntValue)gold;
        //variables.Add("gold", value.Cast(gold));
    }

    private void VariablesToStory(Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }




    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        variables.TryGetValue(variableName, out variableValue);

        return variableValue;
    }

    private void UpdateKingdomStats()
    {
        Ink.Runtime.Object value = null;

        // update gold
        value = GetVariableState("gold");
        _playerKingdom.SetGold(Int32.Parse(value.ToString()));
    }
}
