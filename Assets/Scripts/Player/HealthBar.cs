using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Reference to health")]
    // Player maximum health
    public float maxHealth;
    // Player current health
    public float curHealth;
    [Header("Reference to UI elements")]
    // Reference to Slider
    public Slider healthSlider;
    // Reference to Fill
    public Image healthFill;

    void Update()
    /*{
        healthSlider.value = Mathf.Clamp01(curHealth/maxHealth);
        ManageHelthBar();
    }*/
    {
        healthSlider.value = Mathf.Clamp01(curHealth / maxHealth);
    }

    void ManageHelthBar()
    {
        if (curHealth <= 0 && healthFill.enabled)
        {
            Debug.Log("Dead");
            healthFill.enabled = false;
        }
        else if (!healthFill.enabled && curHealth > 0)
        {
            Debug.Log("Revive");
            healthFill.enabled = enabled;
        }
    }
}