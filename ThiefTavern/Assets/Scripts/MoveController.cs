using System;
using UnityEngine;
using System.Collections.Generic;

public class MoveController : MonoBehaviour
{
    [SerializeField] private bool _isGizmo;
    [SerializeField, Range(0, 10f)] private float _speed;
    [SerializeField, Range(1, 10f)] private float _runSpeedFactor;

    private PlayerInput _input;
    private Transform _transform;

    private Vector2 _contactNormal;
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
                _transform.localScale = new Vector2(-1, 1);
            }
            else if (deltaMove > 0)
            {
                _transform.localScale = new Vector2(1, 1);
            }

            var moveProject = Vector3.ProjectOnPlane(new Vector3(deltaMove, 0), _contactNormal);

            _transform.Translate(moveProject);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        _contactNormal = other.contacts[0].normal;
    }

    private void OnDrawGizmosSelected()
    {
        if (!_isGizmo || !Application.IsPlaying(this))
        {
            return;
        }
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_transform.position, _transform.position - (Vector3) _contactNormal);
    }
}