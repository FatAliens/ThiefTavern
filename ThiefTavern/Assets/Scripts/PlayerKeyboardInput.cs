using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class PlayerKeyboardInput : MonoBehaviour
{
    [FoldoutGroup("Move Events/Left"), SerializeField] private UnityEvent _startMoveLeft;
    [FoldoutGroup("Move Events/Left"), SerializeField] private UnityEvent _endMoveLeft;
    
    [FoldoutGroup("Move Events/Right"), SerializeField] private UnityEvent _startMoveRight;
    [FoldoutGroup("Move Events/Right"), SerializeField] private UnityEvent _endMoveRight;
    
    [FoldoutGroup("Run Events"), SerializeField] private UnityEvent _startRun;
    [FoldoutGroup("Run Events"), SerializeField] private UnityEvent _endRun;
    
    [FoldoutGroup("Hide Events"), SerializeField] private UnityEvent _startHide;
    [FoldoutGroup("Hide Events"), SerializeField] private UnityEvent _endHide;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _startMoveLeft.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _startMoveRight.Invoke();
        }
    }
}
