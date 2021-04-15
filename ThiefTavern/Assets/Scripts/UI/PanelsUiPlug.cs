using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsUiPlug : MonoBehaviour
{
    [SerializeField] private PanelSO panelData;
    [SerializeField] private QuestsPanel eventsPanel;

    public void AddPanel()
    {
        eventsPanel.SerializePanel(panelData);
    }
}
