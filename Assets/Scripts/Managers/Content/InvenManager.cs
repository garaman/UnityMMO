using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenManager : MonoBehaviour
{
    private UI_Inven inventory;
    bool _activeInventory = false;

    private UI_Inven_Item[] _items;
    
    public int Capacity { get; private set; }

    private int _maxCapacity = 32;
    private int _initCapacity = 16;


    private void Awake()
    {
        inventory = Managers.UI.ShowSceneUI<UI_Inven>();
        inventory.gameObject.SetActive(false);
    }
    public void Init()
    {

        _items = new UI_Inven_Item[_maxCapacity];
        Capacity = _initCapacity;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("I click");
            _activeInventory = !_activeInventory;
            inventory.gameObject.SetActive(_activeInventory);

            if(inventory != null)
            {

            }
        }
    }

    public void AddItem(int itemId)
    {
        int index = SlotCheck();        
    }

    public int SlotCheck()
    {
        int index = 0;
        while(index > _items.Length) 
        {
            if (_items[index] == null)
            {
                break;
            }
            index++;

            if(index > Capacity) 
            {
                Capacity = Capacity * 2;
            }           
        }

        return index;
    }

}
