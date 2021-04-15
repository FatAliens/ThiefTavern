using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tevern : MonoBehaviour
{
    [System.Serializable]
    public class Resurs
    {
        public static UnityEvent OnResursChange;
        private int count;
        
    }
    public static Building[] buildings;
    public static int day;

}