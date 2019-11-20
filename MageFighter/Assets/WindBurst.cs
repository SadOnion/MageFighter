using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBurst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] col;
        if (transform.position.x < 0) {
            col = Physics2D.OverlapBoxAll(transform.position + Vector3.right * 3, new Vector2(4, 4), 0);
        }
        else
        {
             col = Physics2D.OverlapBoxAll(transform.position + Vector3.left * 3, new Vector2(4, 4), 0);
        }
        foreach (var item in col)
        {
            Rigidbody2D body =    item.gameObject.GetComponent<Rigidbody2D>();
            if (body != null)body.velocity = new Vector2(-body.velocity.x,body.velocity.y);
        }
        Destroy(gameObject,1);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireCube(transform.position+Vector3.right*3,new Vector2(4,4));
    }


}
