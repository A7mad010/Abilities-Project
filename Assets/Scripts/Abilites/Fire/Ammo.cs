using UnityEngine;

/// <summary>
/// bullet traveling in a straight path
/// </summary>
public class Ammo : MonoBehaviour
{
    [SerializeField] float speedMove = 10; //Speed

    void Update()
    {
        transform.Translate(0, 0, speedMove * Time.deltaTime);
    }
}
