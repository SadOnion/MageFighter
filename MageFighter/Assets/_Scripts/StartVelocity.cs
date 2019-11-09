using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StartVelocity : MonoBehaviour
{
    Rigidbody2D body;
    public Vector2 startVelocity;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        float direction = -Mathf.Sign(transform.position.x);
        body.velocity = new Vector2(startVelocity.x*direction,startVelocity.y);
    }


}
