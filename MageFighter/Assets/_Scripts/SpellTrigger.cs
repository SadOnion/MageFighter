using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellTrigger : MonoBehaviour
{
    public UnityEvent OnCounter;
    [SerializeField] Spell thisSpell;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpellTrigger collisionSpell = collision.gameObject.GetComponent<SpellTrigger>();
        if(collisionSpell != null)
        {
            foreach (var item in thisSpell.counters)
            {
                if (item == collisionSpell.thisSpell) OnCounter?.Invoke();
            }
        }
        else
        {
            IDamagable damageable = collision.gameObject.GetComponent<IDamagable>();
            if(damageable != null)
            {
                damageable.TakeDamage(10);
                Destroy(gameObject);
            }
        }

    }
}
