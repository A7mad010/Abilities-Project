using UnityEngine;

/// <summary>
/// abilities structure
/// </summary>
public interface IAbility
{
    /// <summary>
    /// Name of ability
    /// </summary>
    string Name { get; }

    /// <summary>
    /// cool down  duration of the ability
    /// </summary>
    float CoolDown { get; }

    /// <summary>
    /// get damge of the ability
    /// </summary>
    float Damage { get; }

    /// <summary>
    /// Activeate the ability
    /// </summary>
    void Activate();

    /// <summary>
    /// Initializes the ability with the specified parameters.
    /// </summary>
    void Initialize(string abilityName, float cooldownDuration, float damage);
}
