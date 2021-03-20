using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerStateWonGame : PlayerState
{
    #region Constructor
    readonly Settings _settings;
    readonly PlayerFacade _player;
    public PlayerStateWonGame(Settings settings, PlayerFacade player)
    {
        _settings = settings;
        _player = player;
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
        PublicStaticSettings.CurrentLevel++;
        if (PublicStaticSettings.CurrentLevel > _settings.maxLevels)
        {
            //reset counter, load main menu
            PublicStaticSettings.CurrentLevel = 0;
            LoadSceneMode loadMode = LoadSceneMode.Single;
            SceneManager.LoadScene(PublicStaticSettings.CurrentLevel, loadMode);
        }
        else
        {
            //load next scene
            LoadSceneMode loadMode = LoadSceneMode.Single;
            SceneManager.LoadScene(PublicStaticSettings.CurrentLevel, loadMode);
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
