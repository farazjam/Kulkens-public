using System;
using UnityEngine;
using Zenject;

public class TilePointMoving : TileState
{
    #region Constructor
    readonly Settings _settings;
    readonly TileFacade _tileBehaviour;
    public TilePointMoving(Settings settings, TileFacade tileBehaviour)
    {
        _settings = settings;
        _tileBehaviour = tileBehaviour;
    }
    #endregion

    #region GameLogic

    int curTarget;
    Vector2[] vectorsToMove;

    public override void Start()
    {
        SetupDesiredVectors();
        curTarget = 0;
    }
    void SetupDesiredVectors()
    {
        vectorsToMove = new Vector2[_tileBehaviour.GetPointsToMove.Length];
        for (int i = 0; i < _tileBehaviour.GetPointsToMove.Length; i++)
        {
            vectorsToMove[i] = _tileBehaviour.GetPointsToMove[i].position;
        }
    }

    public override void Update()
    {
        MoveTowardsCheckpoint();
        CheckIfOnPoint();
    }
    void MoveTowardsCheckpoint()
    {
        _tileBehaviour.SetPosition = 
            Vector2.MoveTowards(_tileBehaviour.GetPosition, vectorsToMove[curTarget], 
            Time.deltaTime * _settings.tileMoveSpeed);
    }
    void CheckIfOnPoint()
    {
        if (isOnDesiredPoint(vectorsToMove[curTarget], _tileBehaviour.GetPosition))
            UpdateNextPoint();
    }
    void UpdateNextPoint()
    {
        curTarget = (curTarget + 1) % vectorsToMove.Length;
    }
    bool isOnDesiredPoint(Vector2 desPos, Vector2 curPos)
    {
        int check = 0;
        if (Mathf.Approximately(desPos.x, curPos.x))
            check++;
        if (Mathf.Approximately(desPos.y, curPos.y))
            check++;
        if (check == 2)
            return true;
        else
            return false;

    }
    #endregion

    #region Serialization
    [Serializable]
    public class Settings
    {
        public float tileMoveSpeed;
    }
    public class Factory : PlaceholderFactory<TilePointMoving>
    {

    }

    #endregion
}
