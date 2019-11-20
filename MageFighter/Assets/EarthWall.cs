using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthWall : MonoBehaviour, IDamagable
{
    BoxCollider2D box;
    Animator anim;
    [SerializeField] private int hp;
    [SerializeField] private float duration=3f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        
        DestroyOldWall();
    }
    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0) Die();
    }
    public void EnebleBoxCollider()
    {
        box.enabled = !box.enabled;
    }

    private void DestroyOldWall()
    {

        Collider2D[] sh = Physics2D.OverlapBoxAll(transform.position, Vector2.one, 0);
        foreach (var item in sh)
        {
            item.gameObject.GetComponent<EarthWall>();
            Debug.Log(item);
            if (item != null)
            {
                if (item.Equals(this) == false) Destroy(item.gameObject);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }

    public void Die()
    {
        anim.SetTrigger("Die");
        Destroy(gameObject, 3.5f);
    }
}
