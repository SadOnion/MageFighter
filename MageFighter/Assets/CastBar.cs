using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour
{
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        UpdateBar(0);
    }
    public void UpdateBar(float fillAmount)
    {
        image.fillAmount = fillAmount;
    }
}
