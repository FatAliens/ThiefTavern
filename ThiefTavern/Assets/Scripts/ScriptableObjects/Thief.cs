using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Thief", menuName = "Thief", order = 0)]
    public class Thief : ScriptableObject
    {
        //todo Specialization
        enum Specialization
        {
            One,
            Two,
            Three
        }
        //todo Skill
        enum Skill
        {
            One,
            Two
        }
        [SerializeField] private string name;
        [SerializeField] private Sprite icon;
        [SerializeField] private Specialization specialization;
        [SerializeField] private List<Skill> bufs;
        [SerializeField] private List<Skill> debufs;
    }
}