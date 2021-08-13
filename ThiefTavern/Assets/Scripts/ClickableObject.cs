using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class ClickableObject : MonoBehaviour
{
    [SerializeField]private UnityEvent OnClick;
    [SerializeField] private float SecondsTilDestroy;
    
    private IEnumerator WaitForSeconds()
    {
        OnClick?.Invoke();
        yield return new WaitForSeconds(SecondsTilDestroy);
        Destroy(gameObject);
    }

    public void OnMouseDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.transform == transform)
            {
                Debug.Log("Click to "+ transform.name);
                StartCoroutine(nameof(WaitForSeconds));
            }
        }
    }
}
