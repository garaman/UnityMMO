using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WorldObject
    { 
        Unknown,
        Player,
        Monster,
        Item,
    }

    public enum State
    {
        Die,
        Moving,
        Idle,
        Skill,
    }

    public enum Layer
    {
        Monster=6,
        Ground=7,
        Block=8,
    }

    public enum Scene
    {
        Unkown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    { 
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }
    public enum CameraMode
    {
        QuarterView,
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }

    public enum ItemType
    {
        NONE,
        WEAPON,
        ARMOR,
        CONCUMABLE,
    }

    public enum WeaponType
    {
        NONE,
        SWORD,
        BOW,        
    }

    public enum ArmorType
    {
        NONE,
        HELMET,
        ARMOR,
        BOOTS,
    }

    public enum ConumableType
    {
        NONE,
        POTION,        
    }

}
