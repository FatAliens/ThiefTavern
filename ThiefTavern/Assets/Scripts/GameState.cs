using System;
using System.Collections.Generic;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameState : MonoBehaviour
    {
        //синглтон
        public static GameState Instant;

        [SerializeField] private List<Quest> activeQuests;

        [SerializeField] private int money;

        [SerializeField] private List<Thief> thiefs;
        //todo

        private void Awake()
        {
            //реализация сингтона
            if (Instant == null)
            {
                Instant = this;
            }
        }
    }
}