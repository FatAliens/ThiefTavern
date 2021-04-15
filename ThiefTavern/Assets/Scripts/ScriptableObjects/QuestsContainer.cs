using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestContainer", menuName = "QuestContainer", order = 51)]
public class QuestsContainer : ScriptableObject
{
    public FractionQuests[] FractionQuests = new FractionQuests[4];
}
