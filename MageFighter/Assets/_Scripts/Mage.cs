using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class Mage : MonoBehaviour, IDamagable
{
    public UnityEvent OnHpChange;
    public UnityEvent OnManaChange;
    public ElementalHandler elementalHandler;

    [SerializeField]private int maxHp;
    private int currentHp;
    [SerializeField]private int maxMana;
    private int currentMana;

    private void Start()
    {
        currentHp = maxHp;
        currentMana = maxMana;
    }

    public void CastSpell()
    {
        Spell spellToCast = SpellBook.Instance.GetSpellFromCombo(elementalHandler.GetCurrentCombo());
        if(currentMana >= spellToCast.GetManaCost())
        {
            GameObject spellObject = spellToCast.GetSpellObject();
            if (spellObject != null)
            {
                Instantiate(spellObject, transform.position, Quaternion.identity);
            }
            UseMana(spellToCast.GetManaCost());
            elementalHandler.ClearSlots();

        }
    }

    private void UseMana(int amount)
    {
        currentMana -= amount;
        OnManaChange?.Invoke();
    }
    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        OnHpChange?.Invoke();
    }
    public void SpendMana(int amount)
    {
        currentMana -= amount;
        OnManaChange?.Invoke();
    }
    public float GetHpRatio()
    {
        return (float)currentHp / maxHp;
    }
    public float GetManaRatio()
    {
        return (float)currentMana / maxMana;
    }
}

