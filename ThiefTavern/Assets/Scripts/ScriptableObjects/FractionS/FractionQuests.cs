using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FractionQuests", menuName = "FractionQuests", order = 51)]
public class FractionQuests : ScriptableObject
{
    public QuestsInfo[] Quests;
}
