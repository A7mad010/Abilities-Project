using UnityEngine;

public class Ammo : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField] ParticleSystem[] particalEffect;
    [SerializeField] AudioSource hitAudio;

    public void Play()
    {
        foreach(ParticleSystem partical in particalEffect)
        {
            partical.Play();
        }

        hitAudio?.Play();
    }
}
