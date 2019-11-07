using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour, IDamagable
{
    public ElementalHandler elementalHandler;
    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void CastSpell()
    {
        Debug.Log("Spell");
        elementalHandler.ClearSlots();
    }
}
