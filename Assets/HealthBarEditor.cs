using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//code from: http://gyanendushekhar.com/2019/11/17/create-health-bar-unity-3d/
public class HealthBarEditor : MonoBehaviour
{
    public static Image background;

    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public static void SetHealthBarValue(float value)
    {
        background.fillAmount = value;
        if (background.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (background.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public static float GetHealthBarValue()
    {
        return background.fillAmount;
    }

    /// <summary>
    /// Sets the health bar color
    /// </summary>
    /// <param name="healthColor">Color </param>
    public static void SetHealthBarColor(Color healthColor)
    {
        background.color = healthColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    private void Start()
    {
        background = GetComponent<Image>();
    }
}
