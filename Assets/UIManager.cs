using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Stores the health slider.
    [SerializeField]
    Slider healthSlider;
    // References the player's health.
    public Health playerHealth;

    private void Update()
    {
        // Changes the value of the slider based on player's health.
        healthSlider.value = playerHealth.health;
    }

}
