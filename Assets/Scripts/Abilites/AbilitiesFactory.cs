using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class AbilitiesFactory<T> where T : MonoBehaviour , IAbility
{
    /// <summary>
    /// Create NewObject
    /// </summary>
    /// <param name="abilityObject"></param>
    public void Initialize(string abilityName, float cooldownDuration, float damage)
    {
        
    }
}
