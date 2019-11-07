using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalSlot : MonoBehaviour
{
    Element element;
    Image image;
    bool isEmpty =true;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void AddElement(Element element)
    {
        isEmpty = false;
        this.element = element;
        image.sprite = element.image;
    }
    public void ClearSlot()
    {
        isEmpty = true;
        element = null;
        image.sprite = null; 
    }
    public Element GetElement()
    {
        return element;
    }
    public bool IsEmpty()
    {
        return isEmpty;
    }
}

public enum ElementType
{
    None,
    Fire,
    Water,
    Earth,
    Air
}