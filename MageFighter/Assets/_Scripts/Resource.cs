using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Resource
{
    public int currentValue;
    public ResourceName name;

    public UnityEvent OnResourceChange;

    private int maxValue;
}
public enum ResourceName
{
    Health,
    Mana
}
