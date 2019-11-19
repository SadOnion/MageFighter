using UnityEngine;
using System;

public class SpellBook : MonoBehaviour
{
    #region singleton
    private static SpellBook _instance;
    public static SpellBook Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject obj = new GameObject("SpellBook");
                SpellBook sp = obj.AddComponent<SpellBook>();
                _instance = sp;
            }
            return _instance;
        }
    }
    #endregion

    public Spell[] spells;

    private void Awake()
    {
        _instance = this;
    }

    public  Spell GetSpellFromCombo(ElementType[] combo)
    {
        
        foreach (var item in spells)
        {
            if (item.IsSpellCombo(combo))
            {
                return item;
            }
        }
        return spells[0];
    }
    public Spell GetRandomSpell()
    {
       return spells[UnityEngine.Random.Range(0, spells.Length)];
    }
}
