using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NefesBar : MonoBehaviour
{
    public Slider slider;
    public static int maxBreath = 30;
    public static int currentBreath;

    private void Start()
    {
        maxBreath = 30;
            SetBreath(currentBreath);
        SetMaxBreath(maxBreath);
    }
    public void SetMaxBreath(int Breath)
    {
        slider.maxValue= Breath;
        slider.value= Breath;
    }

    public void SetBreath(int Breath)
    {
        slider.value = Breath;
    }
}
