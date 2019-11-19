using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipX : MonoBehaviour
{
    public float time = .1f;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Switch());
    }

    private IEnumerator Switch()
    {
        sr.flipX = !sr.flipX;
        yield return new WaitForSeconds(time);
        StartCoroutine(Switch());
    }
}
