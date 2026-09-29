using System;
using TMPro; 
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : PlayerStats
{
    [SerializeField] private TextMeshProUGUI healthText;

    private InputAction moveAction;
    float horizontolMovement;

    protected bool isShooted = false;

    void Start()
    {
       
        UpdateHealthText();
    }

    private void Update()
    {
        transform.position += Vector3.right * horizontolMovement * moveSpeed * Time.deltaTime;
        float x = Math.Clamp(transform.position.x, -stop, stop);
        transform.position = new Vector3(x, transform.position.y, 0);

        if (isShooted)
        {
            stopFire -= Time.deltaTime;
            if (stopFire < 0)
            {
                isShooted = false;
                stopFire = 1f;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

       
        UpdateHealthText();

        if (health <= 0)
        {
            Debug.Log("popa");
            Death();
        }
    }

   
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            
            healthText.text = health.ToString();
        }
    }

    public void Death()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }

    public void Movement(InputAction.CallbackContext context)
    {
        horizontolMovement = context.ReadValue<Vector2>().x;
    }

    public void Shot(InputAction.CallbackContext context)
    {
        if (!isShooted)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            isShooted = true;
        }
    }
}