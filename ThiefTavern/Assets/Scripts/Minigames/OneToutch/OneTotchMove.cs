using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTotchMove : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float MaxY;
    [SerializeField] private float MinY;
    private float move = 0;
    private void Update()
    {
        move = Input.GetKey(KeyCode.Space)? Speed : -Speed;
        transform.Translate(0, move * Time.deltaTime, 0, Space.World);
        
    }
}