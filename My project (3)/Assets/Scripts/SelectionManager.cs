using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManaer : MonoBehaviour
{

    public ItemSlot[] HotBarSlots;
    public GameObject selectionSquare;
    public int selectedSlot;

    void Start()
    {
        selectionSquare.SetActive(false);
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            selectedSlot = 0;
            MoveSquare();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            selectedSlot = 1;
            MoveSquare();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            selectedSlot = 2;
            MoveSquare();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            selectedSlot = 3;
            MoveSquare();
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            selectedSlot = 4;
            MoveSquare();
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            selectedSlot = 5;
            MoveSquare();
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            selectedSlot = 6;
            MoveSquare();
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            selectedSlot = 7;
            MoveSquare();
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            selectedSlot = 8;
            MoveSquare();
        }
 
    }

    private void MoveSquare()
    {
        selectionSquare.SetActive(true);
        selectionSquare.transform.SetParent(HotBarSlots[selectedSlot].transform.GetChild(0), false);
    }
}
