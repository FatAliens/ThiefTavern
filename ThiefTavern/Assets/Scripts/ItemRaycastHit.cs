using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemRaycastHit :  MonoBehaviour
{
    [SerializeField] private UnityEvent _shot;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero); 
            if (hit.collider.TryGetComponent<ClickableObject>(out ClickableObject clickable)) 
            {
                _shot.Invoke();
            }
        }
    }
}
