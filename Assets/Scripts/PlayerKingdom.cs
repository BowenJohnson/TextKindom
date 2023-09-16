using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKingdom : MonoBehaviour
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _gold;
    [SerializeField]
    private int _publicOpinion;
    [SerializeField]
    private List<Territories> _territories;
    [SerializeField]
    private List<Troops> _troopTypes;
    [SerializeField]
    private List<Characters> _characters;
    [SerializeField]
    private Dictionary<string, string> policies;

    public void RenameKingdom(string newName)
    {
        _name = newName;
    }

    public string GetName()
    {
        return name;
    }

    private void Awake()
    {
        policies = new Dictionary<string, string>();

        _gold = 1000;
        _publicOpinion = 12;
        StartingTerritories(5);
        StartingTroops("Recruits", 0, 6);
        StartingTroops("Soldiers", 250, 10);
        StartingTroops("Veterans", 0, 12);
        string[] names = {"John", "Sarah", "Jacob", "Erin", "Sven", "Elizabeth", "Kate"};
        StartingCharacters(7, names);
    }

    private void StartingTerritories(int startingSize)
    {
        for (int i = 0; i < startingSize; i++)
        {
            _territories.Add(new Territories());
        }
    }

    private void StartingCharacters(int startingCast, string[] names)
    {
        for (int i = 0; i < startingCast; i++)
        {
            Characters character = new Characters();
            character.SetName(names[i]);
            _characters.Add(character);
        }
    }

    private void StartingTroops(string rank, int count, int combatValue)
    {
        Troops troops;
        troops._rank = rank;
        troops._count = count;
        troops._combatValue = combatValue;

        _troopTypes.Add(troops);
    }
}
