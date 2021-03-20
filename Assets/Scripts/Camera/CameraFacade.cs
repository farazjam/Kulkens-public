using System;
using UnityEngine;
using Zenject;

#pragma warning disable 649

public class CameraFacade : MonoBehaviour
{
    #region Constructor
    CameraState _state;
    CameraFactory _stateFactory;
    [Inject]
    public void Construct(CameraFactory stateFactory)
    {
        _stateFactory = stateFactory;
    }
    #endregion
    #region GameLogic

    //serialized vars
    [SerializeField]
    Transform _cameraTrans, _playerTrans;

    //getters and setters
    public Transform GetCamTrans { get => _cameraTrans; }
    public Transform SetCamTrans { set => _cameraTrans = value; }
    public Vector3 SetCamPos { set => _cameraTrans.position = value; }
    public Transform GetPlayerTrans { get => _playerTrans;  }
    private void Start()
    {
        ChangeState(CameraStates.CameraFollowing);
    }
    private void Update()
    {
        _state.Update();
    }
    private void LateUpdate()
    {
        _state.LateUpdate();
    }

    public void ChangeState(CameraStates state)
    {
        if (_state != null)
        {
            _state.Dispose();
            _state = null;
        }
        _state = _stateFactory.CreateCameraState(state);
        _state.Start();
    }


    #endregion
}
