using UnityEngine;

/// <summary>
/// ability controle , you can add any type of ability
/// </summary>
public class AbilityMananger : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] AbilityBase[] abilities;

    private void Update()
    {
        HandleAbilities();
    }

    /// <summary>
    /// press number of ability from array to use it
    /// </summary>
    void HandleAbilities()
    {
        for(int i = 0; i < abilities.Length;i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                Debug.Log(i);
                abilities[i].Activate();
            }
        }
    }
}
