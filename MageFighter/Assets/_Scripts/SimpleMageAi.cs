
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mage))]
public class SimpleMageAi : MonoBehaviour
{
    private Mage mage;
    public Mage player;
    private Queue<Spell> spellsToCast;
    private bool canCast;
    private float timerToFireball = 5f;
    private Spell fireBall;
    private void Start()
    {
        fireBall = SpellBook.Instance.GetSpellFromCombo(new ElementType[] { ElementType.Earth, ElementType.Earth, ElementType.Earth });
        canCast = true;
        mage = GetComponent<Mage>();
        spellsToCast = new Queue<Spell>();
        player.OnSpellCast += OnPlayerSpell;
    }


    private void Update()
    {
        if (canCast && mage.readyToCast && spellsToCast.Count > 0) StartCoroutine(CastSpell(spellsToCast.Dequeue()));
        timerToFireball -= Time.deltaTime;
        if(timerToFireball<=0)
        {
            timerToFireball = 5;
            spellsToCast.Enqueue(fireBall);
        }
    }
    private IEnumerator CastFireBallAfter(float time)
    {
        mage.elementalHandler.ClearSlots();
        yield return new WaitForSeconds(time);
        Spell spell = SpellBook.Instance.GetRandomSpell();
        foreach (var item in spell.GetCombo())
        {
            mage.elementalHandler.AddElement(item);
            yield return new WaitForSeconds(.2f);
        }
        yield return new WaitForSeconds(.2f);
        mage.CastSpell();
        StartCoroutine(CastFireBallAfter(.5f));
    }
    private IEnumerator CastSpell(Spell spell)
    {
        canCast = false;
        mage.elementalHandler.ClearSlots();
        foreach (var item in spell.GetCombo())
        {
            mage.elementalHandler.AddElement(item);
            yield return new WaitForSeconds(.2f);
        }
        mage.CastSpell();
        canCast = true;
    }

    private void OnPlayerSpell(Spell spell)
    {
        ElementType[] combo = spell.GetCombo();
        if(combo.Length == 1 )
        {
            CounterBasicSpell(combo[0]);
        }
        else
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue > .5f)
            {
                CounterThisSpell(spell);
            }

        }




    }

    private void CounterThisSpell(Spell spell)
    {
        if(spell.counters.Count !=0)
        spellsToCast.Enqueue(spell.counters[Random.Range(0, spell.counters.Count)]);
    }

    private void CounterBasicSpell(ElementType type)
    {
        switch (type)
        {
            case ElementType.Fire:
                spellsToCast.Enqueue(SpellBook.Instance.GetSpellFromCombo(new ElementType[] { ElementType.Water }));
                break;
            case ElementType.Water:
                spellsToCast.Enqueue(SpellBook.Instance.GetSpellFromCombo(new ElementType[] { ElementType.Fire }));
                break;
            case ElementType.Earth:
                spellsToCast.Enqueue(SpellBook.Instance.GetSpellFromCombo(new ElementType[] { ElementType.Earth }));
                break;
        }
    }
}
