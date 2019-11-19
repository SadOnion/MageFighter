using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellTrigger : MonoBehaviour
{
    public UnityEvent OnCounter;
    public Spell thisSpell;
    private float dmgModifier = 1f;
    [SerializeField] private bool destroyAfterAplliedDamage = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ContactLogic(collision.gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactLogic(collision.gameObject);
    }
    private void ContactLogic(GameObject contactObject)
    {
        SpellTrigger collisionSpell = contactObject.GetComponent<SpellTrigger>();
        if (collisionSpell != null)
        {
            
            foreach (var item in thisSpell.counters)
            {
                if (item.Equals(collisionSpell.thisSpell))
                {
                    OnCounter?.Invoke();
                }
            }
        }
        else
        {
            IDamagable damageable = contactObject.GetComponent<IDamagable>();
            if (damageable != null)
            {
                damageable.TakeDamage(Mathf.RoundToInt(thisSpell.GetDmg() * dmgModifier));
                dmgModifier = 1f;
                if (destroyAfterAplliedDamage) Destroy(gameObject);
            }
        }
    }
    public void Counter()
    {
        OnCounter?.Invoke();
    }

    public void ModifyDmgBy(float modifier)
    {
        dmgModifier = modifier;
    }
}
