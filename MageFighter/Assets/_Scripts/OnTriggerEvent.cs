using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    public UnityEvent OnTriggerAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerAction?.Invoke();
    }
}
