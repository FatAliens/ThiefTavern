using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FractionSkinsContainer", menuName = "FractionSkinsContainer", order = 51)]
public class FractionSkinsContainer : ScriptableObject
{
    public FractionSkins[] Fractions = new FractionSkins[4];
}
