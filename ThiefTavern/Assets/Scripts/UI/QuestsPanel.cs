using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections;
using DG.Tweening;

public class QuestsPanel : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] [Range(0f, 20f)] private float DelayTime;

    [Space] [SerializeField] private Color inProgressColor;
    [SerializeField] private Color performedColor;
    [SerializeField] private Color failedColor;

    [Space] private List<GameObject> gameObjects;

    void Start()
    {
        gameObjects = new List<GameObject>();
    }
}

/*public void SerializePanel(PanelSO panel)
{
    if (gameObjects.Count < 5)
    {
        GameObject itemGO = Instantiate(prefab, transform);

        itemGO.transform.localScale = new Vector3(0.7f, 0.7f);
        //LeanTween.scaleX(itemGO, 1, 0.7f).setEaseOutElastic();
        //LeanTween.scaleY(itemGO, 1, 0.7f).setEaseOutElastic();

        QuestPanelUI item = itemGO.GetComponent<QuestPanelUI>();

        item.Title.text = panel.Title;
        item.Description.text = panel.Description;
        item.Money.text = panel.Money.ToString();
        item.State1.text = panel.State1.ToString();
        item.State2.text = panel.State2.ToString();
        item.State3.text = panel.State3.ToString();
        item.State4.text = panel.State4.ToString();

        Color currentColor;
        switch (panel.Status)
        {
            case PanelSO.PanelStatus.InProgress:
                currentColor = inProgressColor;
                break;
            case PanelSO.PanelStatus.Performed:
                currentColor = performedColor;
                break;
            case PanelSO.PanelStatus.Failed:
                currentColor = failedColor;
                break;
            default:
                currentColor = Color.red;
                break;
        }
        itemGO.gameObject.GetComponent<Image>().color = currentColor;

        gameObjects.Add(itemGO);

        StartCoroutine(GOtimer(DelayTime, itemGO));
    }
}

private IEnumerator GOtimer(float delayTime, GameObject panel)
{
    CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
    yield return new WaitForSeconds(delayTime);
    gameObjects.Remove(gameObject);
    canvasGroup.DOFade(0.1f, 0.6f);
    gameObject.transform.DOScaleX(0.5f, 0.6f).SetEase(Ease.InCirc);
    gameObject.transform.DOScaleY(0.5f, 0.6f).SetEase(Ease.InCirc).OnComplete(()=> DOTween.Pause(gameObject));
    if (UnityEngine.Random.Range(0, 2) == 0)
    {
        gameObject.transform.DOMoveX(300, 0.6f).SetRelative();
    }
    else
    {
        gameObject.transform.DOMoveX(-300, 0.6f).SetRelative();
    }
    Destroy(gameObject, 0.7f);
}

private void OnPanelInstanceTwin()
{

}

private void OnPanelDestroyTwin()
{

}
}
*/