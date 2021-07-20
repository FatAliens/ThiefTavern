using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GlobalWalkPoint", menuName = "WalkPoint", order = 52)]
public class GlobalWalkPoint : ScriptableObject
{

    public GameObject AlarmPoint;
    public bool IsActive = false; 
}
