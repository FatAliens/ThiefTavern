using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LossUI : MonoBehaviour
{
    [SerializeField]
    private float ScrollerValue;// вместо float поставить ссылки на значение слайдера подозрительности
    private float PeasantRelationShipValue;// вместо float поставить ссылки на значение отношения с горожанами
    private float CraftsmenRelationShipValue;// вместо float поставить ссылки на значение отношения с ремесленниками
    private float ClergyRelationShipValue;// вместо float поставить ссылки на значение отношения с церквью
    private float AristocracyRelationShipValue;// вместо float поставить ссылки на значение отношения с аристократией
    public GameObject Navigation;
    public Button resetButton;
    void Start()
    {
        Button btn = resetButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClickButton);
    }
    private void Failure()
    {
        if(ScrollerValue <= 0 || PeasantRelationShipValue <=0 || CraftsmenRelationShipValue <= 0 || ClergyRelationShipValue <= 0 || AristocracyRelationShipValue <= 0)
        {
            Navigation = GameObject.Find("Navigation");
            Navigation.SetActive(false);

        }
    }
    private void OnClickButton()
    {
        Navigation.SetActive(true);
        SceneManager.LoadScene("TransitionsUI");
    }

}


