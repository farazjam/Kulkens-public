using System;
public abstract class TileState : IDisposable
{
    public abstract void Update();
    public abstract void Start();

    public virtual void Dispose()
    {
    }
}
