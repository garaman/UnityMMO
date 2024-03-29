using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{ 
    #region Stat
    [Serializable]
    public class Stat
    {
        public int level;
        public int maxhp;
        public int attack;
        public int defense;
        public int totalExp;
    }
    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();

        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
            foreach (Stat stat in stats)
            {
                dict.Add(stat.level, stat);
            }

            return dict;
        }
    }
    #endregion

    #region Item
    [Serializable]
    public class Item
    {
        public int ItemId;
        public string name;
        public int value;
        public int Count;
        public int Slot;
        public int Owner;
    }
    [Serializable]
    public class ItemData : ILoader<int, Item>
    {
        public List<Item> items = new List<Item>();

        public Dictionary<int, Item> MakeDict()
        {
            Dictionary<int, Item> dict = new Dictionary<int, Item>();
            foreach (Item item in items)
            {
                dict.Add(item.ItemId, item);
            }

            return dict;
        }
    }
    #endregion
}