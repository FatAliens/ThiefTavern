﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest", order = 51)]
public class Quest : ScriptableObject
{

    public string QuestName;
    public string QuestDescription;
    public int Location;
    public int SuccessMoney;
    public int FailMoney;
    public int SuccessAristocracy;
    public int FailAristocracy;
    public int SuccessClergy;
    public int FailClergy;
    public int SuccessCraftmen;
    public int FailCraftmen;
    public int SuccessCityzens;
    public int FailCityzens;

}