using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesButton : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    
    public void HouseButton()
    {
        Panel.SetActive(true);
    }

    public void ExitButton()
    {
        Panel.SetActive(false);
    }

}
