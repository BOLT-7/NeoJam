using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceScript : MonoBehaviour
{
    private float timerDuration = 3.0f;
    private float timer;
    private bool canPressKey;

    public HealthBarScript healthBar;
    public Player player;
    public TopDownMovement playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerDuration;
        canPressKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        // Check the timer and update canPressKey accordingly
        if (timer <= 0.5f && !canPressKey)  // Half-second leeway before timer hits zero
        {
            canPressKey = true;  // Allow key press
        }

        if (timer <= 0f)
        {
            timer = timerDuration;  // Reset timer
            canPressKey = false;  // Reset key press check
        }

        // Check for space key press within the allowed time frame
        if (canPressKey && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed right after timer reset!");
            canPressKey = false;  // Prevent multiple logs during the leeway period
            GainHealth(10);
            GainSpeed(20);
        }
    }

    void GainSpeed(int speed)
    {
        playerSpeed.movementSpeed = speed;
    }

    void GainHealth(int health)
    {
        player.currentHealth += health;
        healthBar.SetHealth(player.currentHealth);
    }
}

