using System;
using UnityEngine;
using Zenject;

public enum GameDifficulty
{
    Easy,
    Normal,
    Hard
}

#pragma warning disable 649
public class PlayerFacade : MonoBehaviour
{
    #region Constructors

    SignalBus _signalBus;
    PlayerStateFactory _stateFactory;
    Settings _settings;

    [Inject]
    public void Construct(PlayerStateFactory stateFactory, Settings settings, SignalBus signalBus)
    {
        _stateFactory = stateFactory;
        _settings = settings;
        _signalBus = signalBus;
    }

    #endregion

    #region GameLogic

    //serialized vars
    [SerializeField] Rigidbody2D _rigidBody2D;
    [SerializeField] Transform _respawnPos;

    //private vars
    int _lives;
    GameDifficulty _difficulty;
    PlayerState _state;
    bool runOutOfLives;

    // getters and setters
    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    public Transform Transform { get => transform; }
    public Rigidbody2D Rigidbody2D
    {
        get { return _rigidBody2D; }
    }
    public Transform GetRespawnTransform { get => _respawnPos; }
    public GameDifficulty SetDifficulty { set { _difficulty = value; ChangeDifficulty(); } }
    public int GetCurLives { get {  return PublicStaticSettings.CurrentLives; } }
    public int SetCurLives { set { PublicStaticSettings.CurrentLives = value; } }
    public bool RunOutOfLives { get => runOutOfLives; set { runOutOfLives = value; }  }

    //game logic
    public void Start()
    {
        runOutOfLives = false;
        _difficulty = PublicStaticSettings.GameDifficulty;
        ChangeDifficulty();
        ChangeState(PlayerStates.WaitingForSpawn);
        _signalBus.Fire(new UpdateUILivesSignal($"Lives : {GetCurLives}"));
    }
    public void ChangeDifficulty()
    {
        switch (_difficulty)
        {
            case (GameDifficulty.Easy):
                _lives = _settings.MaxLivesOnEasy;
                break;
            case (GameDifficulty.Normal):
                _lives = _settings.MaxLivesOnMedium;
                break;
            case (GameDifficulty.Hard):
                _lives = _settings.MaxLivesOnHard;
                break;
        }
        PublicStaticSettings.CurrentLives = _lives;
    }
    public void Update()
    {
        _state.Update();
    }
    public void FixedUpdate()
    {
        _state.FixedUpdate();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        _state.OnTriggerEnter2D(collision);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        _state.OnCollisionEnter2D(collision);
    }
    public void ChangeState(PlayerStates state)
    {
        if(_state != null)
        {
            _state.Dispose();
            _state = null;
        }
        _state = _stateFactory.CreateState(state);
        _state.Start();
    }
    public void ShouldRBSleep(bool value)
    {
        switch (value)
        {
            case true:
                _rigidBody2D.Sleep();
                _rigidBody2D.isKinematic = true;
                break;
            case false:
                _rigidBody2D.WakeUp();
                _rigidBody2D.isKinematic = false;
                break;
        }
    }

    #endregion

    #region Serializable
    [Serializable]
    public class Settings
    {
        public int MaxLivesOnEasy,MaxLivesOnMedium,MaxLivesOnHard;
    }
    public class Factory : PlaceholderFactory<PlayerFacade>
    {

    }

    #endregion

}
