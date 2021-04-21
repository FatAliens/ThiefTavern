using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ClosingTest : MonoBehaviour
{
    public Action Closer;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Closer += () => Debug.Log(i);
        }

        Closer();
    }
}