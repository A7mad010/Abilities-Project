using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// you can healing yourSelf
/// </summary>
public class HealAbility : AbilityBase
{
    [Header("Reference")]
    [SerializeField] Health health;

    private void Start()
    {
        //Ability Name , Cool Down , Heal Amount
        Initialize("Healing", 10, 10);
    }

    /// <summary>
    /// Take health points
    /// </summary>
    protected override void UseAbility()
    {
        health.AddHealth(Damage);
    }
}
