using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : BaseController
{
    private int _itemId;
    public string path { get; private set; }

    private void Awake()
    {
        SetInfo();
    }

    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Item;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name}!! {_itemId}!!");
            Managers.Inven.AddItem(_itemId);
            Managers.Game.Despawn(gameObject);
            
        }        
    }
    public void SetInfo()
    {        
        int randvalue = Random.Range(0, 100);

        if(randvalue < 30)
        {
            // 일반 아이템 드랍.
            path = "Item/Item_Normal";
            _itemId = Random.Range(2, 4);
        }
        else if(randvalue < 100) 
        {
            // 포션 아이템 드랍.
            path = "Item/Item_Postion";
            _itemId = 1;
        }
    }
    


}
