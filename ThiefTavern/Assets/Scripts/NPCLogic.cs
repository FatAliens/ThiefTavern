using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NPCLogic : MonoBehaviour
{
    [SerializeField] private float Time;
    [SerializeField] private float YMove;
    [SerializeField] private float XMove;
    [SerializeField] private GameObject canvas;
    [SerializeField] private QuestsPanel questsPanel;
    [SerializeField] private PanelSO panel;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        gameObject.transform.DOMoveX(XMove, 2).SetRelative().OnComplete(() => canvas.SetActive(true));
        gameObject.transform.DOMoveY(YMove, Time).SetRelative().SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(0, 0.2f));
    }

    public void OnClick()
    {
        canvas.SetActive(false);
        gameObject.transform.DOMoveX(-XMove, 4).SetRelative().OnComplete(() =>
        {
            gameObject.transform.DOPause();
            Destroy(gameObject);
        });
        questsPanel.SerializePanel(panel);
    }
}