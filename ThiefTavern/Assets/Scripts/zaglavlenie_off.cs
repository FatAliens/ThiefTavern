using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zaglavlenie_off : MonoBehaviour
{
    public GameObject Button;
    public void onClick()
    {
        Button.SetActive(false);
    }
}
