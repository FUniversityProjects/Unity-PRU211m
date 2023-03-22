using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;


    public void SetHealth(float hp, float maxHP)
    {
        // Slider.gameObject.SetActive(hp < maxHP);
        Slider.maxValue = maxHP;
        Slider.value = hp;

        // Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }

    public void TakeDmgUI(float hp)
    {
        Slider.value = hp;
        /// fill
    }

    // void Update()
    // {
    //   Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    // }
}
