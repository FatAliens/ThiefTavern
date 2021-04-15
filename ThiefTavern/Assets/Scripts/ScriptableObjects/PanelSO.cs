using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Panel", fileName = "PanelSO", order = 1)]
public class PanelSO : ScriptableObject
{
    public enum PanelStatus
    {
        InProgress,
        Performed,
        Failed

    }
    public string Title;
    public string Description;
    public int Money;
    public int State1;
    public int State2;
    public int State3;
    public int State4;
    public PanelStatus Status;
}