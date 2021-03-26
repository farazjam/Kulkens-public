
public enum CameraStates
{
    CameraFollowing
}
public class CameraFactory
{
    readonly CameraFollow.Factory _followFactory;
    public CameraFactory(CameraFollow.Factory followFactory)
    {
        _followFactory = followFactory;
    }
    public CameraState CreateCameraState(CameraStates state)
    {
        switch (state)
        {
            case (CameraStates.CameraFollowing):
                return _followFactory.Create();
        }
        throw ModestTree.Assert.CreateException();

    }
}
