using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mage))]
public class SimpleMageAi : MonoBehaviour
{
    private Mage mage;
    public Element[] combo;
    private void Start()
    {
        mage = GetComponent<Mage>();
        StartCoroutine(CastFireBallAfter(3));
    }

    private IEnumerator CastFireBallAfter(float time)
    {
        yield return new WaitForSeconds(1);
        foreach (var item in combo)
        {
        mage.elementalHandler.AddElement(item);

        }
        yield return new WaitForSeconds(time);
        mage.CastSpell();
        StartCoroutine(CastFireBallAfter(3));

    }
}
