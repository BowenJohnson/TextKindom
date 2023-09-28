using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKingdom : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _gold;
    [SerializeField] private int _publicOpinion;
    [SerializeField] private List<Territories> _territories;
    [SerializeField] private Troops _Recruits;
    [SerializeField] private Troops _Soldiers;
    [SerializeField] private Troops _Veterans;
    [SerializeField] private List<Characters> _characters;
    [SerializeField] private Dictionary<string, string> policies;

    private void Awake()
    {
        policies = new Dictionary<string, string>();
    }

    public void RenameKingdom(string newName)
    {
        _name = newName;
    }

    public void AddGold(int gold)
    {
        _gold += gold;
    }

    public void AddPublicOpinion(int opinion)
    {
        _publicOpinion = opinion;
    }

    public void StartingTerritories(int startingSize)
    {
        for (int i = 0; i < startingSize; i++)
        {
            // using ScriptableObject.CreateInstance because Territories is a scriptable object
            _territories.Add(ScriptableObject.CreateInstance<Territories>());
        }
    }

    public void StartingCharacters(int startingCast, string[] names)
    {
        for (int i = 0; i < startingCast; i++)
        {
            // using ScriptableObject.CreateInstance because characters is a scriptable object
            Characters character = ScriptableObject.CreateInstance<Characters>();
            character.SetName(names[i]);
            _characters.Add(character);
        }
    }

    public void StartingTroops(int recNum, int recCombatValue, int solNum, int solCombatValue, int vetNum, int vetCombatValue)
    {
        _Recruits._rank = "Recruits";
        _Recruits._count = recNum;
        _Recruits._combatValue = recCombatValue;

        _Soldiers._rank = "Soldiers";
        _Soldiers._count = solNum;
        _Soldiers._combatValue = solCombatValue;

        _Veterans._rank = "Veterans";
        _Veterans._count = vetNum;
        _Veterans._combatValue = vetCombatValue;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetGold()
    {
        return _gold;
    }

    public void SetGold(int newGold)
    {
        _gold = newGold;
    }

    public int GetPublicOpinion()
    {
        return _publicOpinion;
    }

    public int GetNumTerritories()
    {
        return _territories.Count;
    }

    public int GetnumCharacters()
    {
        return _characters.Count;
    }

    public Troops GetRecruits()
    {
        return _Recruits;
    }

    public Troops GetSoldiers()
    {
        return _Soldiers;
    }

    public Troops GetVeterans()
    {
        return _Veterans;
    }
}
