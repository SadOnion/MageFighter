using System;
using UnityEngine;
[CreateAssetMenu(fileName="New Spell",menuName="Spell")]
public class Spell :ScriptableObject
{
    public ElementType[] thisSpellCombo;
    public GameObject spellObject;

    public bool IsSpellCombo(ElementType[] combo)
    {
        if(combo.Length == thisSpellCombo.Length)
        {
            Array.Sort(combo);
            Array.Sort(thisSpellCombo);
            for (int i = 0; i < combo.Length; i++)
                if (thisSpellCombo[i] != combo[i])
                    return false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
