using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalHandler : MonoBehaviour
{
    private Mage mage;
    public ElementalSlot[] slots;
    private int nextElementSlot = 0;
    
    public CastBar castBar;

    private void Start()
    {
        mage = GetComponentInParent<Mage>();
    }
    public void AddElement(Element elem)
    {
        if (nextElementSlot < slots.Length)
        {
            slots[nextElementSlot].AddElement(elem);
            nextElementSlot++;
        }
        StopAllCoroutines();
        StartCoroutine(CastSpellAfterIdleFor(1f));
    }

    private IEnumerator CastSpellAfterIdleFor(float time)
    {
        yield return new WaitForSeconds(time);
        mage.CastSpell();
    }
    public void AddElement(ElementType type)
    {
        Element[] elements = Resources.FindObjectsOfTypeAll<Element>();
        foreach (var item in elements)
        {
            if (item.type == type) AddElement(item);
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
    public ElementType[] GetCurrentCombo()
    {
        List<ElementType> list = new List<ElementType>();
        foreach (var item in slots)
        {
            if(item.IsEmpty() == false)
            {
                list.Add(item.GetElement().type);
            }
        }
        return list.ToArray();
    }
    private void OnValidate()
    {
        slots = GetComponentsInChildren<ElementalSlot>();
    }
}
