using System;
using UnityEngine;

/// <summary>
/// abilities Creation Center , you can create any ability from this base
/// </summary>
public abstract class AbilityBase : MonoBehaviour, IAbility
{
    public string Name { get; private set;}
    public float CoolDown { get; private set; }
    public float Damage { get; private set; }

    /// <summary>
    /// save time (last time you use the ability)
    /// </summary>
    private float m_coolDownLastTime;

    /// <summary>
    /// Initializes the ability with the specified parameters.
    /// </summary>
    /// <param name="abilityName"></param>
    /// <param name="cooldownDuration"></param>
    /// <param name="damage"></param>
    /// <exception cref="ArgumentException"></exception>
    public void Initialize(string abilityName, float cooldownDuration, float damage)
    {
        if (string.IsNullOrEmpty(abilityName))
        {
            throw new ArgumentException("Ability name cannot empty");
        }

        Name = abilityName;
        CoolDown = cooldownDuration;
        Damage = damage;
    }

    /// <summary>
    /// Activate the ability
    /// </summary>
    public void Activate()
    {
        if(IsCoolDownEnd())
        {
            return;
        }

        UseAbility();
        m_coolDownLastTime = Time.time;
    }

    /// <summary>
    /// Check if cool down is end
    /// </summary>
    /// <returns></returns>
    protected bool IsCoolDownEnd()
    {
        if (Time.time - m_coolDownLastTime < CoolDown)
        {
            Debug.Log($"Cool Down : {Time.time - m_coolDownLastTime}");
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// you can here add ability`s (proprty or detials)
    /// </summary>
    protected abstract void UseAbility();
}
