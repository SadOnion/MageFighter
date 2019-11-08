using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Image hp;
    public Image mana;
    public Mage mageToObserve;
  
    public void UpdateUI()
    {
        Debug.Log(mageToObserve.GetManaRatio());
        hp.fillAmount = mageToObserve.GetHpRatio();
        mana.fillAmount = mageToObserve.GetManaRatio();
    }
}
