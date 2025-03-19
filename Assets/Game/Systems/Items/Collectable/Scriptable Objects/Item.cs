using System;
using UnityEngine;

public abstract class Item: ScriptableObject {
    public new string name;
    public string description;
    public Sprite sprite;

    public string Name => name;
    public Sprite UISprite => sprite;


    public abstract void Use();
}