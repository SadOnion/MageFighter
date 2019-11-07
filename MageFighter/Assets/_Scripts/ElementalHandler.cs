using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalHandler : MonoBehaviour
{
    public ElementalSlot[] slots;
    private int nextElementSlot = 0;
    public Element def;

    public void AddElement(Element elem)
    {
        if (nextElementSlot < slots.Length)
        {
            slots[nextElementSlot].AddElement(elem);
            nextElementSlot++;
        }
    }
    
    public void ClearSlots()
    {
        nextElementSlot = 0;
        foreach (var item in slots)
        {
            item.ClearSlot();
        }
    }
    public bool HasAnyElements()
    {
        if(nextElementSlot == 0)
        {
            return !slots[0].IsEmpty();
        }
        else
        {
            return true;
        }

    }
    private void OnValidate()
    {
        slots = GetComponentsInChildren<ElementalSlot>();
    }
}
