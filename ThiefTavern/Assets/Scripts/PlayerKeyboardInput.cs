using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class PlayerKeyboardInput : MonoBehaviour
{
    [FoldoutGroup("Move Events"), SerializeField]
    private UnityEvent _changeMoveVector;

    [FoldoutGroup("Run Events"), SerializeField]
    private UnityEvent _startRun;

    [FoldoutGroup("Run Events"), SerializeField]
    private UnityEvent _endRun;

    [FoldoutGroup("Hide Events"), SerializeField]
    private UnityEvent _startHide;

    [FoldoutGroup("Hide Events"), SerializeField]
    private UnityEvent _endHide;

    void Update()
    {
        
        
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _startRun.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            _startHide.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _endRun.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            _endHide.Invoke();
        }
    }
}