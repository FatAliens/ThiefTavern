using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkinContainer", menuName = "SkinContainer", order = 51)]
public class SkinsContainer : ScriptableObject
{
    public FractionSkins[] Fractions = new FractionSkins[4];
}
