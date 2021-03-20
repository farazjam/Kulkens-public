using System;
using UnityEngine;
using Zenject;

public abstract class PlayerState : IDisposable
{
    public virtual void Start()
    {
        // optionally overridden
    }
    public virtual void Update()
    {
        // optionally overridden
    }
    public virtual void FixedUpdate()
    {
        // optionally overridden
    }
    public virtual void Dispose()
    {
        // optionally overridden
    }
    public virtual void OnTriggerEnter2D (Collider2D collision)
    {
        // optionally overridden
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // optionally overridden
    }
}
