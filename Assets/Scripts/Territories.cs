using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Territories : ScriptableObject
{
    [SerializeField]
    private string _name;

    // gives a random amount of gold each turn (between 60-80)
    public int GoldPerTurn()
    {
        int gold;
        
        gold = Random.Range(60, 80);

        return gold;
    }
    // gives a random amount of soldier/recruits based on kingdom policy
    public int TroopsPerTurn()
    {
        int troops;

        troops = Random.Range(2, 4);

        return troops;
    }
}
