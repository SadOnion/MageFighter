using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Mage))]
public class InputHandler : MonoBehaviour
{
   
    private Mage mage;
    private void Start()
    {
        mage = GetComponent<Mage>();
    }

    public void AddElement(Element element)
    {
        if (mage.ReadyToCast)
        {
            mage.elementalHandler.AddElement(element);
        }
    }
  
   
}
