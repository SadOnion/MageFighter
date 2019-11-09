using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Resource : IRationable
{
    public int value { get; private set; }
    private int maxValue;
    public ResourceName name;

    public ResourceEvent OnResourceChange;


    public Resource()
    {
        maxValue = GameConst.DEFAULT_RESOURCE_AMOUNT;
        value = maxValue;
    }
    public bool Use(int amount)
    {
        if (value - amount < 0) return false;
        else
        {
            value -= amount;
            OnResourceChanged();
            return true;
        }
    }
    public void UseAll()
    {
        value = 0;
        OnResourceChanged();
    }
    public void Add(int amount)
    {
        value += amount;
        if (value > maxValue) value = maxValue;
        OnResourceChanged();
    }
    public float Ratio()
    {
        return (float)value / maxValue;
    }

    protected virtual void OnResourceChanged()
    {
        OnResourceChange?.Invoke(this);
    }

}
[Serializable]
public class ResourceEvent : UnityEvent<Resource>
{
    
}
public enum ResourceName
{
    Health,
    Mana
}
public interface IRationable
{
    float Ratio();
}
