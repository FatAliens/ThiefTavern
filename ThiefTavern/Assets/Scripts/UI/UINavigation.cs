using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class UINavigation : MonoBehaviour
{
    [PropertyOrder(-1), Button, PropertyTooltip("Автоматически заполнить все поля")]
    void AutoSetParams()
    {
        CenterPanel = GameObject.FindGameObjectWithTag("CenterNavigationPanel")?.GetComponent<Transform>() ?? null;
        TopPanel = GameObject.FindGameObjectWithTag("TopNavigationPanel")?.GetComponent<Transform>() ?? null;
        DownPanel = GameObject.FindGameObjectWithTag("DownNavigationPanel")?.GetComponent<Transform>() ?? null;
        LeftPanel = GameObject.FindGameObjectWithTag("LeftNavigationPanel")?.GetComponent<Transform>() ?? null;
        RightPanel = GameObject.FindGameObjectWithTag("RightNavigationPanel")?.GetComponent<Transform>() ?? null;
        IsColsoleLog = false;
        TweenDuration = 0.5f;
    }

    private enum NavigationPosition
    {
        Center = 0,
        Top = 1,
        Down = 3,
        Left = 2,
        Right = 5,
        TopLeft = 6,
        DownLeft = 4
    }

    [FoldoutGroup("Panels"), ValidateInput("@$value != null", "This member is null!")]
    public Transform CenterPanel;
    [FoldoutGroup("Panels"), ValidateInput("@$value != null", "This member is null!")]
    public Transform TopPanel;
    [FoldoutGroup("Panels"), ValidateInput("@$value != null", "This member is null!")]
    public Transform DownPanel;
    [FoldoutGroup("Panels"), ValidateInput("@$value != null", "This member is null!")]
    public Transform LeftPanel;
    [FoldoutGroup("Panels"), ValidateInput("@$value != null", "This member is null!")]
    public Transform RightPanel;

    [Range(0, 4)]
    public float TweenDuration;

    public bool IsColsoleLog;

    [SerializeField, HideInEditorMode, DisableIf("@true")]
    private int xOffset;
    [SerializeField, HideInEditorMode, DisableIf("@true")]
    private int yOffset;

    [SerializeField, HideInEditorMode, DisableIf("@true")]
    private NavigationPosition currentPosition = NavigationPosition.Center;

    private bool isTweening = false;
    public LossUI loss;
    private Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;
        
        //Get screen resolution
        xOffset = Mathf.CeilToInt(Camera.main.pixelWidth);
        yOffset = Mathf.CeilToInt(Camera.main.pixelHeight);

        //Positionate panels
        TopPanel.transform.DOLocalMoveY(yOffset, 0);
        DownPanel.transform.DOLocalMoveY(-yOffset, 0);
        LeftPanel.transform.DOLocalMoveX(-xOffset, 0);
        RightPanel.transform.DOLocalMoveX(xOffset, 0);
    }

    //Move Top and Down panel to center X coordinate
    private void MoveStatsToCenterPanel()
    {
        MoveStats(0);
    }

    //Move Top and Down panel to left X coordinate
    private void MoveStatsToLeftPanel()
    {
        MoveStats(-xOffset);
    }

    private void MoveStats(int TargetXPosition)
    {
        TopPanel.transform.DOLocalMoveX(TargetXPosition, 0);
        DownPanel.transform.DOLocalMoveX(TargetXPosition, 0);
    }

    private void ConsoleLog(string text)
    {
        if (IsColsoleLog)
        {
            Debug.Log(text);
        }
    }

    private void MoveNavigation(NavigationPosition targetPosition)
    {
        if (isTweening)
        {
            return;
        }

        currentPosition = targetPosition;

        //это говнокод, но я хз как еще это сделать
        switch (targetPosition)
        {
            case NavigationPosition.Center:
                TweenNavigation(new Vector2(0, 0));
                break;
            case NavigationPosition.Top:
                TweenNavigation(new Vector2(0, -yOffset));
                break;
            case NavigationPosition.Down:
                TweenNavigation(new Vector2(0, yOffset));
                break;
            case NavigationPosition.Left:
                TweenNavigation(new Vector2(xOffset, 0));
                break;
            case NavigationPosition.Right:
                TweenNavigation(new Vector2(-xOffset, 0));
                break;
            case NavigationPosition.TopLeft:
                TweenNavigation(new Vector2(xOffset, -yOffset));
                break;
            case NavigationPosition.DownLeft:
                TweenNavigation(new Vector2(xOffset, yOffset));
                break;
        }
    }

    private void TweenNavigation(Vector2 targetPosition)
    {
        isTweening = true;
        this.gameObject.transform.DOLocalMoveX(targetPosition.x, TweenDuration).OnComplete(() => isTweening = false);
        this.gameObject.transform.DOLocalMoveY(targetPosition.y, TweenDuration);
    }
    public void ResetCheck()
    {
        if(loss.IsLoaded == true)
        {
            SceneManager.LoadScene("TransitionUI");
        }
    }

    public void OnLeftSwipe()
    {
        ConsoleLog("Left Swipe");

        if (currentPosition == NavigationPosition.Center)
        {
            MoveNavigation(NavigationPosition.Left);
            MoveStatsToLeftPanel();
        }
        else if (currentPosition == NavigationPosition.Right)
        {
            MoveNavigation(NavigationPosition.Center);
        }
    }
    public void OnRightSwipe()
    {
        ConsoleLog("Right Swipe");

        if (currentPosition == NavigationPosition.Left)
        {
            MoveNavigation(NavigationPosition.Center);
            MoveStatsToCenterPanel();
        }
        else if (currentPosition == NavigationPosition.Center)
        {
            MoveNavigation(NavigationPosition.Right);
        }
    }
    public void OnTopSwipe()
    {
        ConsoleLog("Top Swipe");

        if (currentPosition == NavigationPosition.Left)
        {
            MoveNavigation(NavigationPosition.TopLeft);
        }
        else if (currentPosition == NavigationPosition.Center)
        {
            MoveNavigation(NavigationPosition.Top);
        }
        else if (currentPosition == NavigationPosition.Down)
        {
            MoveNavigation(NavigationPosition.Center);
        }
        else if (currentPosition == NavigationPosition.DownLeft)
        {
            MoveNavigation(NavigationPosition.Left);
        }
    }
    public void OnDownSwipe()
    {
        ConsoleLog("Down Swipe");

        if (currentPosition == NavigationPosition.Left)
        {
            MoveNavigation(NavigationPosition.DownLeft);
        }
        else if (currentPosition == NavigationPosition.Center)
        {
            MoveNavigation(NavigationPosition.Down);
        }
        else if (currentPosition == NavigationPosition.Top)
        {
            MoveNavigation(NavigationPosition.Center);
        }
        else if (currentPosition == NavigationPosition.TopLeft)
        {
            MoveNavigation(NavigationPosition.Left);
        }
    }
}
