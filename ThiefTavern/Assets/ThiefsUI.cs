using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class ThiefsUI : MonoBehaviour
{
    [Serializable]
    class Thief
    {
        public string Name;
    }

    [SerializeField] private List<Thief> thiefs;
    [SerializeField] private Thief currentThief;
    [SerializeField] private GameObject thiefPanelPrefab;
    [SerializeField] private RectTransform thiefUIList;

}