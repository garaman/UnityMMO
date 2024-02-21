using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenManager : MonoBehaviour 
{
    private Item[] _items;
    
    public int Capacity { get; private set; }

    private int _maxCapacity = 32;
    private int _initCapacity = 16;

    public void Init()
    {
        _items = new Item[_maxCapacity];
        Capacity = _initCapacity;
    }


    public void AddItem(int itemId)
    {

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
