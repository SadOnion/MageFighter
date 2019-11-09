using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellColision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        IDamagable damageable = collision.gameObject.GetComponent<IDamagable>();
        if(damageable != null)
        {
            damageable.TakeDamage(10);
            Destroy(gameObject);
        }

    }
}
