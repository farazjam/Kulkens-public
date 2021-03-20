using Zenject;

public enum TileStates
{
    TwoPointMoving
}
public class TileFactory
{
    readonly TilePointMoving.Factory _twoPointMovingFactory;
    public TileFactory(TilePointMoving.Factory twoPointMovingFactory)
    {
        _twoPointMovingFactory = twoPointMovingFactory;
    }
    public TileState CreateTileState(TileStates tileState)
    {
        switch (tileState)
        {
            case (TileStates.TwoPointMoving):
                return _twoPointMovingFactory.Create();
        }
        throw ModestTree.Assert.CreateException();

    }
}
