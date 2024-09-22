using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is a ScriptableObject used to track the data that our items should contain.
 */

[CreateAssetMenu(menuName = "Scriptable Object/Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    [Header("Data for Gameplay Only")]
    //Gameplay data like a price, weapon stats, and range go here

    [Header("Data for UI Only")]
    //data that's only needed for the inventory can go here.
    public bool stackable = true;

    [Header("Data for Both Gameplay and UI")]
    //things that would be needed for both the gameplay and the UI go here. Display images,
    //data for the UI and the gameplay interacting, and even example 3 goes here.
    public Sprite displayImage;
}
