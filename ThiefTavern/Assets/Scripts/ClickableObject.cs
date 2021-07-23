using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour
{
    
    [SerializeField]private UnityEvent OnClick;
    
    private void ItemCollection()
    {
        StartCoroutine(nameof(WaitForSeconds));
    }
    private IEnumerator WaitForSeconds()
    {
        OnClick?.Invoke();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void OnMouseDown()
    {
        ItemCollection();
    }

   
}
