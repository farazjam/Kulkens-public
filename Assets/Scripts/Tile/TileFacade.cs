using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#pragma warning disable 649

public class TileFacade : MonoBehaviour
{
    #region Constructor
    TileState _state;
    TileFactory _stateFactory;
    [Inject]
    public void Construct(TileFactory tileFactory)
    {
        _stateFactory = tileFactory;
    }
    #endregion

    #region GameLogic

    //serialized vars
    [SerializeField] TileStates tileState;
    [SerializeField] Transform[] pointsToMove;


    //getters and setters
    public Transform GetTransform { get => transform; }
    public Transform[] GetPointsToMove { get => pointsToMove; }
    public Vector2 GetPosition { get => transform.position; }
    public Vector2 SetPosition { set => transform.position = value; }

    private void Start()
    {
        ChangeState(tileState);
    }
    private void Update()
    {
        _state.Update();
    }
    public void ChangeState(TileStates state)
    {
        if (_state != null)
        {
            _state.Dispose();
            _state = null;
        }
        _state = _stateFactory.CreateTileState(state);
        _state.Start();
    }

    #endregion
}
