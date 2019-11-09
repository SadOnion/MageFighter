using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public Mage mage;

    public void UpdateStat()
    {
        bar.fillAmount = mage.GetHpRatio();
    }
}
