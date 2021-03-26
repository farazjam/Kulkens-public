using System;
using UnityEngine;
using Zenject;

public class CameraFollow : CameraState
{
    #region Constructor
    readonly Settings _settings;
    readonly CameraFacade _camBehaviour;
    public CameraFollow(Settings settings, CameraFacade camBehaviour)
    {
        _settings = settings;
        _camBehaviour = camBehaviour;
    }
    #endregion
    #region GameLogic

    public override void LateUpdate()
    {
        _camBehaviour.SetCamPos = 
            Vector2.Lerp(_camBehaviour.GetCamTrans.position, _camBehaviour.GetPlayerTrans.position, Time.deltaTime * _settings.CameraLerpSpeed);
        _camBehaviour.SetCamPos = new Vector3(_camBehaviour.GetCamTrans.position.x, _camBehaviour.GetCamTrans.position.y, -10f);
    }

    #endregion
    #region Serialization
    [Serializable]
    public class Settings
    {
        public float CameraLerpSpeed;
    }
    public class Factory : PlaceholderFactory<CameraFollow>
    {

    }

    #endregion
}
