public enum PlayerStates
{
    Alive,
    Dead,
    WaitingForSpawn,
    WonGame
}
public class PlayerStateFactory 
{
    readonly PlayerStateAlive.Factory _aliveFactory;
    readonly PlayerStateDead.Factory _deadFactory;
    readonly PlayerStateAwaitingSpawn.Factory _awaitingSpawnFactory;
    readonly PlayerStateWonGame.Factory _wonGameFactory;

    public PlayerStateFactory(
        PlayerStateAlive.Factory aliveFactory,
        PlayerStateDead.Factory deadFactory,
        PlayerStateAwaitingSpawn.Factory awaitingSpawnFactory,
        PlayerStateWonGame.Factory wonGameFactory
        )
    {
        _aliveFactory = aliveFactory;
        _deadFactory = deadFactory;
        _awaitingSpawnFactory = awaitingSpawnFactory;
        _wonGameFactory = wonGameFactory;
    }
    public PlayerState CreateState(PlayerStates state)
    {
        switch (state)
        {
            case PlayerStates.Alive:
                {
                    return _aliveFactory.Create();
                }
            case PlayerStates.Dead:
                {
                    return _deadFactory.Create();
                }
            case PlayerStates.WaitingForSpawn:
                {
                    return _awaitingSpawnFactory.Create();
                }
            case PlayerStates.WonGame:
                {
                    return _wonGameFactory.Create();
                }
        }
        throw ModestTree.Assert.CreateException();
    }
}
