using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : BaseController
{
    private int _itemId;
    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Item;
        _itemId = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name}!!");

            Managers.Game.Despawn(gameObject);
            
        }        
    }
    public string DropItemKind()
    {
        string path = null;
        int randvalue = Random.Range(0, 100);

        if(randvalue < 30)
        {
            // 일반 아이템 드랍.
            path = "Item/Item_Normal";
            _itemId = Random.Range(1, 3);
        }
        else if(randvalue < 100) 
        {
            // 포션 아이템 드랍.
            path = "Item/Item_Postion";
            _itemId = 1;
        }
                
        return path;
    }
    


}
