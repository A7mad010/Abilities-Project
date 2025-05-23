using System;
using UnityEngine;

/// <summary>
/// Health System
/// </summary>
public class Health : MonoBehaviour
{
    /// <summary>
    /// Health Amount
    /// </summary>
    public float health { get; private set; }
    public event Action OnChangeHealth;

    /// <summary>
    /// Add health
    /// </summary>
    /// <param name="amount"></param>
    public void AddHealth(float amount)
    {
        health += amount;
        OnChangeHealth.Invoke();
    }

    /// <summary>
    /// Take Damge
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamge(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            health = 0;
        }

        OnChangeHealth.Invoke();
    }
}
