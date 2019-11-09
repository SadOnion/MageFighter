using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class Mage : MonoBehaviour, IDamagable
{
    public ElementalHandler elementalHandler;

    public Resource health;
    public Resource mana;

    private void Start()
    {
        StartCoroutine(ReplenishMana());
    }
    public void CastSpell()
    {
        Spell spellToCast = SpellBook.Instance.GetSpellFromCombo(elementalHandler.GetCurrentCombo());
        if(mana.Use(spellToCast.GetManaCost()))
        {
            GameObject spellObject = spellToCast.GetSpellObject();
            if (spellObject != null)
            {
                Instantiate(spellObject, transform.position+Vector3.right*-Math.Sign(transform.position.x), Quaternion.identity);
            }
            
            elementalHandler.ClearSlots();

        }
        else
        {
            // No Mana
        }
    }


    public void TakeDamage(int amount)
    {
        if (health.Use(amount) == false)
        {
            health.UseAll();
            Die();
        }
    }
    private IEnumerator ReplenishMana()
    {
        yield return new WaitForSeconds(1);
        mana.Add(2);
        StartCoroutine(ReplenishMana());

    }

    private void Die()
    {
        throw new NotImplementedException();
    }
}

