using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FractionQuestsContainer", menuName = "FractionQuestsContainer", order = 51)]
public class FractionQuestsContainer : ScriptableObject
{
    public FractionQuests[] FractionQuests = new FractionQuests[4];
}
