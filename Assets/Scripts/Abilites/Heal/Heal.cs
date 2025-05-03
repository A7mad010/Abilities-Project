using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// you can healing yourSelf
/// </summary>
public class Heal : AbilityBase
{
    [Header("Refrence")]
    [SerializeField] Slider healUI; //Slider UI

    [Header("Settings")]
    [SerializeField] float healing = 25; //The amount of healing

    float m_heal; //Save player`s heal

    private void Start()
    {
        Initialize("Heal", 10, 0);
        m_heal = healUI.value;
    }

    /// <summary>
    /// Taking damage and losing health points 
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        m_heal -= damage;
    }

    /// <summary>
    /// Take health points
    /// </summary>
    protected override void UseAbility()
    {
        StopCoroutine(TargetHeal(0));
        StartCoroutine(TargetHeal(m_heal + healing));
    }

    /// <summary>
    /// Increase health bar smoothly
    /// </summary>
    /// <param name="targetHeal"></param>
    /// <returns></returns>
    IEnumerator TargetHeal(float targetHeal)
    {
        float value = 0;

        while(value < 1)
        {
            value += Time.deltaTime;
            m_heal = Mathf.Lerp(m_heal, targetHeal, value);
            healUI.value = m_heal;

            yield return null;
        }
    }
}
