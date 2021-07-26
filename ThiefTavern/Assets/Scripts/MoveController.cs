using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class MoveController : MonoBehaviour
{
    [SerializeField, Range(0, 10f)] private float _speed;
    [SerializeField, Range(1, 10f)] private float _runSpeedFactor;
    [SerializeField] private LayerMask _raycastFilter;
    [SerializeField] private Transform _raycastPosition;

    private PlayerInput _input;
    private Transform _transform;
    private SpriteRenderer _renderer;

    private float _horizontalMove;
    private bool _isHide;
    private bool _isRun;
    private bool _onHideZone;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Hide.started += (context) => OnHideStarted();
        _input.Player.Hide.performed += (context) => OnHidePerformed();

        _input.Player.Run.started += (context) => OnRunStarted();
        _input.Player.Run.performed += (context) => OnRunPerformed();

        _transform = transform;
        _renderer = GetComponent<SpriteRenderer>();
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
            _renderer.DOColor(Color.gray, 1f);
        }
        else
        {
            if (_renderer.color != Color.white)
            {
                _renderer.DOColor(Color.white, 1f);
            }

            float deltaMove = _horizontalMove * Time.fixedDeltaTime * _speed;

            deltaMove = _isRun ? deltaMove * _runSpeedFactor : deltaMove;


            if (deltaMove < 0)
            {
                _transform.localScale = new Vector2(-1,1);
            }
            else if (deltaMove > 0)
            {
                _transform.localScale = new Vector2(1,1);
            }

            var raycastHit = Physics2D.Raycast(_raycastPosition.position, Vector2.down, 100, _raycastFilter);
            if (raycastHit.collider != null)
            {
                _transform.rotation = Quaternion.Euler(0,0,raycastHit.collider.gameObject.transform.rotation.eulerAngles.z);
                Debug.Log(raycastHit.collider.name);
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