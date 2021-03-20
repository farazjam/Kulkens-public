using UnityEngine;
using Zenject;
using System;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public PlayerSettings player;
    public CameraSettings cameraSettings;
    public TileSettings tileSettings;
    [Serializable]
    public class PlayerSettings
    {
        public PlayerFacade.Settings PlayerMainSettings;
        public PlayerStateAlive.Settings StateAlive;
        public PlayerStateDead.Settings StateDead;
        public PlayerStateAwaitingSpawn.Settings StateAwaitingRespawn;
        public PlayerStateWonGame.Settings StateWonGame;
    }
    [Serializable]
    public class CameraSettings
    {
        public CameraFollow.Settings cameraFollowingSettings;
    }
    [Serializable]
    public class TileSettings
    {
        public TilePointMoving.Settings tileTwoPointMovingSettings;
    }
    public override void InstallBindings()
    {
        Container.BindInstance(player.StateAlive);
        Container.BindInstance(player.StateDead);
        Container.BindInstance(player.StateAwaitingRespawn);
        Container.BindInstance(player.StateWonGame);
        Container.BindInstance(player.PlayerMainSettings);
        Container.BindInstance(cameraSettings.cameraFollowingSettings);
        Container.BindInstance(tileSettings.tileTwoPointMovingSettings);

        
    }
}

