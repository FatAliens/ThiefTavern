using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtons : MonoBehaviour
{
    [SerializeField]
    private Image ButtonImage;
    [SerializeField]
    private Color StartColor;
    [SerializeField]
    private Color ButtonDownColor;
    [SerializeField]
    private GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        ButtonImage = GetComponent<Image>();
        StartColor = ButtonImage.color;
    }

    public void ButtonDown()
    {
        ButtonImage.color = ButtonDownColor;
    }

    public void ButtonUP()
    {
        ButtonImage.color = StartColor;
    }

    public void ExitButton()
    {
        Panel.SetActive(false);
    }

    public void AreaButton()
    {
        Panel.SetActive(true);
    }

}
