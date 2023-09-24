using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsController : MonoBehaviour
{
    [SerializeField] private PlayerKingdom _playerKingdom;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private TMP_Text _publicOpinionText;
    [SerializeField] private TMP_Text _territoriesText;
    [SerializeField] private TMP_Text _charactersText;
    [SerializeField] private TMP_Text _recruitsText;
    [SerializeField] private TMP_Text _soldiersText;
    [SerializeField] private TMP_Text _verteransText;
    public bool isActive { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _playerKingdom = _playerKingdom.GetComponent<PlayerKingdom>();
    }

    // grab all player kingdom stats and push them to the stats UI
    public void PushStats()
    {
        _nameText.text = _playerKingdom.GetName();
        _goldText.text = _playerKingdom.GetGold().ToString();
        _publicOpinionText.text = _playerKingdom.GetPublicOpinion().ToString();
        _territoriesText.text = _playerKingdom.GetNumTerritories().ToString();
        _charactersText.text = _playerKingdom.GetnumCharacters().ToString();
        _recruitsText.text = _playerKingdom.GetRecruits()._count.ToString();
        _soldiersText.text = _playerKingdom.GetSoldiers()._count.ToString();
        _verteransText.text = _playerKingdom.GetVeterans()._count.ToString();
    }
}
