using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player Health UI
/// </summary>
public class HealthUI : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] Slider bar;
    [SerializeField] Health playerHealth;

    Coroutine m_onChange;

    private void Start()
    {
        playerHealth.OnChangeHealth += OnChange;
    }

    public void OnChange()
    {
        if(m_onChange != null)
        {
            StopCoroutine(m_onChange);
        }

        m_onChange = StartCoroutine(ChangeHealth(playerHealth.health));
    }

    IEnumerator ChangeHealth(float targetAmount)
    {
        float value = 0;

        while(value < 1)
        {
            value += Time.deltaTime;
            bar.value = Mathf.Lerp(bar.value, playerHealth.health, value);

            yield return null;
        }
    }
}


