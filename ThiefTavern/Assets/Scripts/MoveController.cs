using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class MoveController : MonoBehaviour
{
    [SerializeField, Range(0, 10f)] private float _speed;
    [SerializeField, Range(1, 10f)] private float _runSpeedFactor;

    private PlayerInput _input;
    private Transform _transform;

    private float _horizontalMove;
    private bool _isHide;
    private bool _isRun;
    private bool _onHideZone;

    private void Awake()
    {
        _input = new PlayerInput();
        _transform = transform;
        
        ConfigureInput();
    }

    private void ConfigureInput()
    {
        _input.Player.Hide.started += (context) => OnHideStarted();
        _input.Player.Hide.performed += (context) => OnHidePerformed();

        _input.Player.Run.started += (context) => OnRunStarted();
        _input.Player.Run.performed += (context) => OnRunPerformed();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnHideStarted()
    {
        _isHide = true;
    }

    private void OnHidePerformed()
    {
        _isHide = false;
    }

    private void OnRunStarted()
    {
        _isRun = true;
    }

    private void OnRunPerformed()
    {
        _isRun = false;
    }

    private void Update()
    {
        _horizontalMove = _input.Player.Move.ReadValue<float>();
    }

    //даже не пытайтесь разобраться - это нужно переписывать
    private void FixedUpdate()
    {
        if (_isHide && _onHideZone)
        {
            //todo hide animation
        }
        else
        {
            float deltaMove = _horizontalMove * Time.fixedDeltaTime * _speed;

            if (_isRun)
            {
                deltaMove *= _runSpeedFactor;
            }
            
            if (deltaMove < 0)
            {
                _transform.localScale = new Vector2(-1,1);
            }
            else if (deltaMove > 0)
            {
                _transform.localScale = new Vector2(1,1);
            }

            _transform.Translate(deltaMove, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hide_zone"))
        {
            _onHideZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hide_zone"))
        {
            _onHideZone = false;
        }
    }
}