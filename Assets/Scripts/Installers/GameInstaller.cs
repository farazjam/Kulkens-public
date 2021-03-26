using Zenject;

public class GameInstaller : MonoInstaller <GameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerStateFactory>().AsSingle();
        Container.BindFactory<PlayerStateAlive, PlayerStateAlive.Factory>().WhenInjectedInto<PlayerStateFactory>();
        Container.BindFactory<PlayerStateDead, PlayerStateDead.Factory>().WhenInjectedInto<PlayerStateFactory>();
        Container.BindFactory<PlayerStateAwaitingSpawn, PlayerStateAwaitingSpawn.Factory>().WhenInjectedInto<PlayerStateFactory>();
        Container.BindFactory<PlayerStateWonGame, PlayerStateWonGame.Factory>().WhenInjectedInto<PlayerStateFactory>();

        Container.Bind<CameraFactory>().AsSingle();
        Container.BindFactory<CameraFollow, CameraFollow.Factory>().WhenInjectedInto<CameraFactory>();

        Container.Bind<TileFactory>().AsSingle();
        Container.BindFactory<TilePointMoving, TilePointMoving.Factory>().WhenInjectedInto<TileFactory>();


    }

}