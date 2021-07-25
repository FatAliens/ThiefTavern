using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIspriteController : MonoBehaviour
{
    [SerializeField]
    public AIPath aIPath;
    [SerializeField]
    public float NewScale;
    private void FixedUpdate()
    {
        if(aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(NewScale, NewScale, 1);
        }
        else if(aIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-NewScale, NewScale, 1);
        }
    }
}
