using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClickableObject : MonoBehaviour
{
    
    [SerializeField]private UnityEvent OnClick;
    [SerializeField] private float SecondsTilDestroy;
    
    public void ItemCollection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(nameof(WaitForSeconds));
        }
    }
    private IEnumerator WaitForSeconds()
    {
        OnClick?.Invoke();
        yield return new WaitForSeconds(SecondsTilDestroy);
        Destroy(gameObject);
    }


   
}
