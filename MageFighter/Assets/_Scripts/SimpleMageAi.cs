using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mage))]
public class SimpleMageAi : MonoBehaviour
{
    private Mage mage;
    public Element[] combo;
    private void Start()
    {
        mage = GetComponent<Mage>();
        StartCoroutine(CastFireBallAfter(3));
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
}
