using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderView : MonoBehaviour
{
    public Transform END_GAME;
    public Transform dark;
    int a = 0;

    [SerializeField] private Slider DangerLineSlider;
    [SerializeField] private Text DangerLineText;
    [SerializeField] [Range(0, 1)] private float DangerLineValue;

    [Space] [SerializeField] private Image State1Image;
    [SerializeField] private Text State1Text;
    [SerializeField] [Range(0, 1)] private float State1Value;
    [Space] [SerializeField] private Image State2Image;
    [SerializeField] private Text State2Text;
    [SerializeField] [Range(0, 1)] private float State2Value;

    [Space] [SerializeField] private Image State3Image;
    [SerializeField] private Text State3Text;
    [SerializeField] [Range(0, 1)] private float State3Value;

    [Space] [SerializeField] private Image State4Image;
    [SerializeField] private Text State4Text;
    [SerializeField] [Range(0, 1)] private float State4Value;

    [Space] [SerializeField] private Text MoneyText;
    [SerializeField] private int MoneyValue = 0;

    private void FixedUpdate()
    {
        SerializeSliders();
    }

    private void SerializeSliders()
    {
        DangerLineSlider.value = DangerLineValue;

        State1Image.fillAmount = State1Value;
        State2Image.fillAmount = State2Value;
        State3Image.fillAmount = State3Value;
       State4Image.fillAmount = State4Value;

        MoneyText.text = MoneyValue.ToString() + "$";

        DangerLineText.text = (DangerLineValue * 100).ToString() + "%";

        State1Text.text = (Mathf.Floor(State1Value * 100)).ToString() + "%";
        State2Text.text = (Mathf.Floor(State2Value * 100)).ToString() + "%";
        State3Text.text = (Mathf.Floor(State3Value * 100)).ToString() + "%";
        State4Text.text = (Mathf.Floor(State4Value * 100)).ToString() + "%";
        
        /*if (State1Slider.value == 1)
        {
            END_GAME.gameObject.SetActive(true);
        }
        if (State2Slider.value == 1)
        {
            END_GAME.gameObject.SetActive(true);
        }
        if (State3Slider.value == 1)
        {
            END_GAME.gameObject.SetActive(true);
        }
        if (State4Slider.value == 1)
        {
            END_GAME.gameObject.SetActive(true);
        }
        if (DangerLineSlider.value == 1)
        {
            END_GAME.gameObject.SetActive(true);
        }
        else { }*/
        



    }
    public void OnClickOclock()
    { 
        if (a == 0 )
        {
            DangerLineSlider.value = DangerLineSlider.value - 10;
            a = a + 1;
            dark.gameObject.SetActive(true);
        }
        if (a == 1)
        {
            DangerLineSlider.value = DangerLineSlider.value - 10;
            a = a - 1;
            dark.gameObject.SetActive(false);
        }

    }

    private void OnDrawGizmosSelected()
    {
        SerializeSliders();
    }
}