using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObjectChecker : MonoBehaviour
{
    private int _collectableItemsCount;
    private ClickableObject ScriptOfClick;
    
   
    void Start()
    {
        ItemCountChecker(); // ищет все объекты на сцене и записывает их количество в _collectableItemsCount 
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ItemCountChecker()
    {
        ClickableObject[] items = FindObjectsOfType<ClickableObject>();
        
        for (int i = 0; i < items.Length; i++)
        {
            _collectableItemsCount++;
        }
        Debug.Log(_collectableItemsCount);
        
    }
    private void LevelCompleted()
    {
        if(ScriptOfClick.itemCollected == _collectableItemsCount)
        {
            Debug.Log("Level completed");
        }
    }
   
}
