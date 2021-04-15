using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New HouseInfo", menuName = "HouseInfo", order = 51)]
public class HousesInfo : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField]
    private string HouseName;

    [SerializeField]
    private string Fraction;

    [SerializeField]
    private int Level;

    [SerializeField]
    private int MoneyRecoveryMin;

    [SerializeField]
    private int MoneyRecoveryMax;

}
