using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Stores the health slider.
    [Header("UI:"), SerializeField]
    Slider healthSlider;
    // References the player's health.
    public Health playerHealth;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        // Changes the value of the slider based on player's health.
        healthSlider.value = playerHealth.health;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            // GAME MANGER PAUSE.
        }
    }
   
    public void OnResumeClicked()
    {
        pauseMenu.SetActive(false);
        // GAME MANAGER UPAUSE
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }

}
