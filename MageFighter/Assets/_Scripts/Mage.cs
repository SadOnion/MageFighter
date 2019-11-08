using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Mage : MonoBehaviour, IDamagable
{
    private int maxHp;
    private int currentHp;
    private int maxMana;
    private int currentMana;

    public ElementalHandler elementalHandler;


    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        
    }

    public void CastSpell()
    {
        Spell spellToCast = SpellBook.Instance.GetSpellFromCombo(elementalHandler.GetCurrentCombo());
        if(spellToCast.spellObject !=null)Instantiate(spellToCast.spellObject, transform.position, Quaternion.identity);
        elementalHandler.ClearSlots();
    }
}
