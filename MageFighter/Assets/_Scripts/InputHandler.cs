using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Mage))]
public class InputHandler : MonoBehaviour
{
    public Element up;
    public Element down;
    public Element left;
    public Element right;
    public ElementalHandler elementalHandler;
    private Mage mage;
    private void Start()
    {
        mage = GetComponent<Mage>();
    }
    private void Update()
    {
        HandleInput();
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            elementalHandler.AddElement(up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            elementalHandler.AddElement(down);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            elementalHandler.AddElement(right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            elementalHandler.AddElement(left);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            elementalHandler.ClearSlots();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (elementalHandler.HasAnyElements())
            { 
                mage.CastSpell();
            }
        }
    }
}
