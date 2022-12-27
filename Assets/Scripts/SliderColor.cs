using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    Slider healthSlider;
    public Image fill;

    public int threshold;

    public Color low;
    public Color high;

    public static bool tired;

    //public Text ozoneText;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        tired = false;
    }

    private void Update()
    {
        if (healthSlider.value > threshold)
        {
            fill.color = high;
            tired = false;
        }
        if (healthSlider.value < threshold && healthSlider.value > 0)
        {
            fill.color = low;
            tired = true;
        }

        if (healthSlider.value < 1)
        {
            fill.color = Color.clear;
            tired = false;
        }
    }

}
