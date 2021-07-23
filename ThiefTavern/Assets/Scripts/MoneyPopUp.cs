using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyPopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int _moneyAmmount)
    {
        textMesh.SetText(_moneyAmmount.ToString());
    }
}
