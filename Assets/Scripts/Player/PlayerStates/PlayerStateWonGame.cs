using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerStateWonGame : PlayerState
{
    #region Constructor
    readonly Settings _settings;
    readonly PlayerFacade _player;
    MenuSettings _menuSettings;
    public PlayerStateWonGame(Settings settings, PlayerFacade player, MenuSettings menuSettings)
    {
        _settings = settings;
        _player = player;
        _menuSettings = menuSettings;
    }
    #endregion

    #region GameLogic

    public override void Start()
    {
        Debug.Log("We won");
        _player.ShouldRBSleep(true);
        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        _menuSettings.SetCurrentLevel = _menuSettings.GetCurrentLevel + 1 ;
        if (_menuSettings.GetCurrentLevel > _settings.maxLevels)
        {
            //reset counter, load main menu
            _menuSettings.SetCurrentLevel = 0;
            LoadSceneMode loadMode = LoadSceneMode.Single;
            SceneManager.LoadScene(_menuSettings.GetCurrentLevel, loadMode);
        }
        else
        {
            //load next scene
            LoadSceneMode loadMode = LoadSceneMode.Single;
            SceneManager.LoadScene(_menuSettings.GetCurrentLevel, loadMode);
        }
    }

    #endregion

    #region Serializable
    [Serializable]
    public class Settings
    {
        public int maxLevels;
    }
    public class Factory : PlaceholderFactory<PlayerStateWonGame>
    {

    }

    #endregion

}
