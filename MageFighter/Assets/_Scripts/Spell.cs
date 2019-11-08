using System;
using UnityEngine;
[CreateAssetMenu(fileName="New Spell",menuName="Spell")]
public class Spell :ScriptableObject
{
    [SerializeField] private ElementType[] thisSpellCombo;
    [SerializeField] private GameObject spellObject;
    [SerializeField] private int manaCost;
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
    public ElementType[] GetCombo() => thisSpellCombo;
    public GameObject GetSpellObject() => spellObject;
    public int GetManaCost() => manaCost;
}