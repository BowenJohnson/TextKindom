using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private bool _busy;

    private void Awake()
    {
        _busy = false;
        this._name = "";
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetBusy(bool busy)
    {
        _busy = busy;
    }

    public bool GetBusy()
    {
        return _busy;
    }
}
