using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerKingdom _playerKingdom;
    [SerializeField] private NewGameController _newGameController;
    [SerializeField] private CourtController _courtController;
    [SerializeField] private CharactersController _charactersController;
    [SerializeField] private PoliciesController _policiesController;
    [SerializeField] private StatsController _statsController;

    // references to the menu UI's
    [SerializeField] private GameObject _newGameMenu;
    [SerializeField] private GameObject _courtMenu;
    [SerializeField] private GameObject _charactersMenu;
    [SerializeField] private GameObject _policiesMenu;
    [SerializeField] private GameObject _statsMenu;
    [SerializeField] private GameObject _tabsUI;

    [SerializeField] private bool _skipNewGame;

    // Start is called before the first frame update
    void Start()
    {
        _newGameController = _newGameController.GetComponent<NewGameController>();
        _playerKingdom = _playerKingdom.GetComponent<PlayerKingdom>();
        _courtController = _courtController.GetComponent<CourtController>();
        _charactersController = _charactersController.GetComponent<CharactersController>();
        _statsController = _statsController.GetComponent<StatsController>();

        NewGameSetup();
    }

    private void NewGameSetup()
    {
        // set-up starting player kingdom
        _playerKingdom.AddGold(1000);
        _playerKingdom.AddPublicOpinion(12);
        _playerKingdom.StartingTerritories(5);
        _playerKingdom.StartingTroops(0, 6, 250, 10, 0, 12);
        string[] names = { "John", "Sarah", "Jacob", "Erin", "Sven", "Elizabeth", "Kate" };
        _playerKingdom.StartingCharacters(7, names);

        if (!_skipNewGame)
        {
            // get kingdom name
            ActivateNewGameMenu();
            _newGameController.PushText("Name your Kingdom.");
        }
        else
        {
            _tabsUI.SetActive(true);
            ActivateCourtMenu();
        }
    }

    public void ActivateNewGameMenu()
    {
        _charactersController.isActive = false;
        _charactersMenu.SetActive(false);

        _policiesController.isActive = false;
        _policiesMenu.SetActive(false);

        _statsController.isActive = false;
        _statsMenu.SetActive(false);

        _courtController.isActive = false;
        _courtMenu.SetActive(false);

        _newGameController.TargetInputTextBox();
    }

    public void ActivateCourtMenu()
    {
        _charactersController.isActive = false;
        _charactersMenu.SetActive(false);

        _policiesController.isActive = false;
        _policiesMenu.SetActive(false);

        _statsController.isActive = false;
        _statsMenu.SetActive(false);

        _courtMenu.SetActive(true);
        _courtController.isActive = true;
    }

    public void ActivateCharactersMenu()
    {
        _policiesController.isActive = false;
        _policiesMenu.SetActive(false);

        _statsController.isActive = false;
        _statsMenu.SetActive(false);

        _courtController.isActive = false;
        _courtMenu.SetActive(false);

        _charactersMenu.SetActive(true);
        _charactersController.isActive = true;
    }

    public void ActivatePoliciesMenu()
    {
        _charactersController.isActive = false;
        _charactersMenu.SetActive(false);

        _statsController.isActive = false;
        _statsMenu.SetActive(false);

        _courtController.isActive = false;
        _courtMenu.SetActive(false);

        _policiesMenu.SetActive(true);
        _policiesController.isActive = true;
    }

    public void ActivateStatsMenu()
    {
        _charactersController.isActive = false;
        _charactersMenu.SetActive(false);

        _policiesController.isActive = false;
        _policiesMenu.SetActive(false);

        _courtController.isActive = false;
        _courtMenu.SetActive(false);

        _statsMenu.SetActive(true);
        _statsController.PushStats();
        _statsController.isActive = true;
    }

    public void NewGameEnd()
    {
        // deactivate new game menu
        _newGameMenu.SetActive(false);

        // activate tabs
        _tabsUI.SetActive(true);

        // activate stats menu
        ActivateStatsMenu();
    }
}
