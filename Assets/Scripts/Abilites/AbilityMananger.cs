using UnityEngine;

public class AbilityMananger : MonoBehaviour
{
    [SerializeField] MonoBehaviour abilityComponent;
    private IAbility m_ability;

    private void Start()
    {
        m_ability = abilityComponent as IAbility;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            m_ability.UseAbility();
        }
    }
}
