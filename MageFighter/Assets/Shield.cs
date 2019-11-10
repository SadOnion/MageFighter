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
    }
}
