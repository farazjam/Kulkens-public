using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerStateDead : PlayerState
{
    #region Constructor
    readonly SignalBus _signalBus;
    readonly Settings _settings;
    readonly PlayerFacade _player;
    MenuSettings _menuSettings;
    public PlayerStateDead(Settings settings, PlayerFacade player, SignalBus signalBus, MenuSettings menuSettings)
    {
        _settings = settings;
        _player = player;
        _signalBus = signalBus;
        _menuSettings = menuSettings;
    }

    #endregion
    #region GameLogic

    public override void Start()
    {
        Debug.Log("we ded");
        GameObject go = GameObject.Instantiate(
            _settings.deathParticles, _player.Position,Quaternion.identity,_player.transform.parent);
        _player.ShouldRBSleep(true);
        _player.SetCurLives = _player.GetCurLives - 1;
        _signalBus.Fire(new UpdateUILivesSignal($"Lives: {_player.GetCurLives}"));
        _player.RunOutOfLives = _player.GetCurLives < 1 ? true : false;
        if (_player.RunOutOfLives)
            RestartGame();
        else
        {
            _player.Position = _player.GetRespawnTransform.position;
            _player.ChangeState(PlayerStates.WaitingForSpawn);
        }

    }
    void RestartGame()
    {
        _menuSettings.SetCurrentLevel = 0;
        LoadSceneMode loadMode = LoadSceneMode.Single;
        SceneManager.LoadScene(_menuSettings.GetCurrentLevel, loadMode);
    }
    public override void Dispose()
    {
        base.Dispose();
    }

    #endregion

    #region Serialization
    [Serializable]
    public class Settings
    {
        public GameObject deathParticles;
    }
    public class Factory : PlaceholderFactory<PlayerStateDead>
    {

    }
    #endregion
}
