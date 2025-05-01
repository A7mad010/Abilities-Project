using NUnit.Framework;
using System;
using UnityEngine;

public class Fire : MonoBehaviour , IAbility
{
    [Header("Refrence")]
    [SerializeField] Transform centerTransform;
    [SerializeField] Ammo fireObject;

    [Header("Settings")]
    [SerializeField] float rayCastDestinace;
    [SerializeField] float coolDown = 1;
    float m_lastTime;

    RaycastHit m_rayCastHit;

    private void Start()
    {
        IsValid();
    }

    public void UseAbility()
    {
        if ((Time.time - m_lastTime) < coolDown) return;

        ApplyRayCastPoint();
        ApplyFire();

        m_lastTime = Time.time;
    }

    private void ApplyRayCastPoint()
    {
        bool isHit = Physics.Raycast(centerTransform.position, centerTransform.forward, out m_rayCastHit, rayCastDestinace);
    }

    private void ApplyFire()
    {
        ReUseAmmo(m_rayCastHit.point);
    }

    private void ReUseAmmo(Vector3 point)
    {
        fireObject.transform.position = point;
        fireObject.Play();
    }

    private void IsValid()
    {
        string errorDebug = "";

        if (centerTransform == null)
        {
            errorDebug += $"{this.name} : null > cannot find the ( {centerTransform} ) \n";
        }
        if (fireObject == null)
        {
            errorDebug += $"{this.name} : null > cannot find the ( {fireObject} ) \n";
        }

        if (errorDebug != "")
        {
            Debug.Log(errorDebug);
            enabled = false;
        }
    }
}
