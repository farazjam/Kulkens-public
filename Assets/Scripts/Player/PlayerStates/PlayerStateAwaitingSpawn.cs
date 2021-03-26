using System;
using UnityEngine;
using Zenject;

public class PlayerStateAwaitingSpawn : PlayerState
{
    #region Constructor
    readonly Settings _settings;
    readonly PlayerFacade _player;
    public PlayerStateAwaitingSpawn(Settings settings, PlayerFacade player)
    {
        _settings = settings;
        _player = player;
    }
    #endregion

    #region GameLogic
    public override void Start()
    {
        _player.ShouldRBSleep(true);
    }
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_settings.CanSpawn)
            {
                Debug.Log("we spawned");
                _player.ChangeState(PlayerStates.Alive);
            }
        }
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
        public bool CanSpawn;
    }
    public class Factory : PlaceholderFactory<PlayerStateAwaitingSpawn>
    {

    }

    #endregion
}
