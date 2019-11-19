using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] Element protectionFrom;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(protectionFrom.elementColor.r, protectionFrom.elementColor.g, protectionFrom.elementColor.b,spriteRenderer.color.a);
        DestroyOldShield();

    }
    private void DestroyOldShield()
    {
        
        Shield[] sh = transform.parent.GetComponentsInChildren<Shield>();
        foreach (var item in sh)
        {
            if (item.Equals(this) == false) Destroy(item.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpellTrigger spell = collision.gameObject.GetComponent<SpellTrigger>();
        if(spell != null)
        {
            if(Array.Exists(spell.thisSpell.GetCombo(), x => x == protectionFrom.type))
            {
                spell.Counter();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
