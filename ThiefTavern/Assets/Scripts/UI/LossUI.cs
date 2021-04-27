using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossUI : MonoBehaviour
{
    [SerializeField]
    private float ScrollerValue;// вместо float поставить ссылки на значение слайдера подозрительности
    private float PeasantRelationShipValue;// вместо float поставить ссылки на значение отношения с горожанами
    private float CraftsmenRelationShipValue;// вместо float поставить ссылки на значение отношения с ремесленниками
    private float ClergyRelationShipValue;// вместо float поставить ссылки на значение отношения с церквью
    private float AristocracyRelationShipValue;// вместо float поставить ссылки на значение отношения с аристократией
    public bool IsLoaded = false;
    private void Failure()
    {
        if(ScrollerValue <= 0 || PeasantRelationShipValue <=0 || CraftsmenRelationShipValue <= 0 || ClergyRelationShipValue <= 0 || AristocracyRelationShipValue <= 0)
        {
            SceneManager.LoadScene("LossUI");
            IsLoaded = true;
        }
    }
}


