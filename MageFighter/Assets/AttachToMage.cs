using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToMage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(transform.position, new Vector2(2.5f, .5f), 0);
        foreach (var item in col)
        {
            Mage mage = item.gameObject.GetComponent<Mage>();
            if (mage != null)
            {
                transform.SetParent(mage.transform);
                transform.localPosition= Vector3.zero;
                break;
            }
        }
    }
   
}
