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
            // Debug.Log("Initialized global dialogue variable " + name + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        KingdomVarsToStory(story);
        // VariablesToStory needs to happen before assigning the listener
        //VariablesToStory(story);
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

    // gets the current kingdom stats and ports them into the dialogue 
    private void KingdomVarsToStory(Story story)
    {
        story.variablesState["gold"] = _playerKingdom.GetGold();
        story.variablesState["publicOpinion"] = _playerKingdom.GetPublicOpinion();
        story.variablesState["recruits"] = _playerKingdom.GetRecruits()._count;
        story.variablesState["soldiers"] = _playerKingdom.GetSoldiers()._count;
        story.variablesState["veterans"] = _playerKingdom.GetVeterans()._count;
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
        // TODO: Figure out why vars get reset depending on choice
        // KingdomVarsToStory(story);
    }


    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        variables.TryGetValue(variableName, out variableValue);

        return variableValue;
    }

    // syncs the current kingdom stats to stats from the dialogue
    private void UpdateKingdomStats()
    {
        //int gold = Int32.Parse(story.variablesState.GetVariableWithName("gold").ToString());
        Ink.Runtime.Object value = null;

        // update gold
        value = GetVariableState("gold");
        _playerKingdom.SetGold(Int32.Parse(value.ToString()));
        //_playerKingdom.SetGold(Int32.Parse(story.variablesState.GetVariableWithName("gold").ToString()));

        //// update public opinion
        value = GetVariableState("publicOpinion");
        _playerKingdom.SetPublicOpinion(Int32.Parse(value.ToString()));

        //// update recruits
        value = GetVariableState("recruits");
        _playerKingdom.SetNumRecruits(Int32.Parse(value.ToString()));

        //// update soldiers
        value = GetVariableState("soldiers");
        _playerKingdom.SetNumSoldiers(Int32.Parse(value.ToString()));

        //// update veterans
        //value = GetVariableState("veterans");
        //_playerKingdom.SetNumVeterans(Int32.Parse(value.ToString()));
    }
}
