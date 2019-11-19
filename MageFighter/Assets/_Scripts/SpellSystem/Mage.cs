using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mage : MonoBehaviour, IDamagable
{
    public ElementalHandler elementalHandler;
    public Resource health;
    public Resource mana;
    public delegate void SpellFunc(Spell spell);
    public event SpellFunc OnSpellCast;
    public bool readyToCast { get; private set; }
    private void Start()
    {
        readyToCast = true;
        StartCoroutine(ReplenishMana());
    }
    public void CastSpell()
    {
        if (readyToCast)
        {
                Spell spellToCast = SpellBook.Instance.GetSpellFromCombo(elementalHandler.GetCurrentCombo());
                if(mana.Use(spellToCast.GetManaCost()))
                {
                    GameObject spellObject = spellToCast.GetSpellObject();
                    
                    OnSpellCast?.Invoke(spellToCast);
                    StartCoroutine(Casting(spellObject,spellToCast));

                }
                else
                {
                    //nomana
                }
        }
        
    }

    private IEnumerator Casting(GameObject spellObject, Spell spellToCast)
    {
        readyToCast = false;
        float timer = 0;
        float timeToCast = GameConst.CAST_TIME * spellToCast.GetCombo().Length;
        while(timer < timeToCast)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
            elementalHandler.castBar.UpdateBar(timer/timeToCast);
        }
        if (spellToCast != null)
        {
            Instantiate(spellObject, transform.position + Vector3.right * -Math.Sign(transform.position.x), Quaternion.identity);
        }
        elementalHandler.castBar.UpdateBar(0);
        readyToCast = true;
        elementalHandler.ClearSlots();
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

