using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMultiplier : MonoBehaviour
{
    public float speedModifier;

    private void Start()
    {
        if (transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(body.velocity.x*speedModifier, body.velocity.y);
    }
}
