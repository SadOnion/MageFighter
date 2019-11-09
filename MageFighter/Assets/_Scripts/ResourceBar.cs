using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ResourceBar : MonoBehaviour
{
    private Image bar;

    private void Start()
    {
        bar = GetComponent<Image>();
    }
    public void UpdateResourceBar(Resource resource)
    {
        bar.fillAmount = resource.Ratio();
    }
}
