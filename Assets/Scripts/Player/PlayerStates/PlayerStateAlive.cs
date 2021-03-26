using System;
using UnityEngine;
using Zenject;


public class PlayerStateAlive : PlayerState
{
    #region Constructor
    //constructor
    readonly Settings _settings;
    readonly PlayerFacade _player;
    public PlayerStateAlive(Settings settings, PlayerFacade player)
    {
        _settings = settings;
        _player = player;
    }
    #endregion

    #region GameLogic

    float _jumpTimer;
    bool _canJump;
    bool _isMovingRight;

    // input vars
    Vector2 _moveInput;
    bool _jumpKeyPressed;
    public override void Start()
    {
        _player.ShouldRBSleep(false);
        _moveInput = new Vector2();
    }
    public override void Update()
    {
        AssignInput();
        MovePlayer();
        Timers();
    }
    void AssignInput()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = Input.GetAxis("Vertical");
        _jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
    }
    void MovePlayer()
    {
        _isMovingRight = (_player.Rigidbody2D.velocity.x >= 0) ? true : false;
        if(_moveInput.x > 0)
        {
            //pressing right
            //if we moving left, we still need to apply movement
            if(!_isMovingRight)
                ApplyHorizontalMovement();
            else if (_player.Rigidbody2D.velocity.magnitude < _settings.maxVelocity)
            {
                ApplyHorizontalMovement();
            }
        }
        if(_moveInput.x < 0)
        {
            //pressing left
            //if we moving right, we still need to apply movement
            if (_isMovingRight)
                ApplyHorizontalMovement();
            else if (_player.Rigidbody2D.velocity.magnitude < _settings.maxVelocity)
            {
                ApplyHorizontalMovement();
            }
        }
        if (_jumpKeyPressed && _canJump)
        {
            _player.Rigidbody2D.AddForce(Vector2.up * _settings.jumpForce,ForceMode2D.Impulse);
            _canJump = false;
        }
    }
    void ApplyHorizontalMovement()
    {
        _player.Rigidbody2D.AddForce(new Vector2(_moveInput.x, 0) * _settings.moveSpeed);
    }
    void Timers()
    {
        _jumpTimer += Time.deltaTime;
        if(_jumpTimer > _settings.jumpTimerMax)
        {
            _jumpTimer = 0;
            _canJump = true;
        }
    }
    public override void Dispose()
    {
        base.Dispose();
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Hazard"))
        {
            _player.ChangeState(PlayerStates.Dead);
        }
        if (collision.collider.CompareTag("WinTag"))
        {
            _player.ChangeState(PlayerStates.WonGame);
        }
    }

    #endregion

    #region SettingsSerialization

    [Serializable]
    public class Settings
    {
        public float moveSpeed;
        public float jumpForce;
        public float maxVelocity;
        public float jumpTimerMax;
    }
    public class Factory : PlaceholderFactory<PlayerStateAlive>
    {

    }
    #endregion
}
