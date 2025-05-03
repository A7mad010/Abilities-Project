using UnityEngine;

/// <summary>
/// Allows you to shoot
/// </summary>
public class Fire : AbilityBase
{
    [Header("Reference")]
    [SerializeField] Transform shootCenter; //The point from which the ammunition will originate
    [SerializeField] GameObject ammoObj; //The ammunition object

    private void Start()
    {
        Initialize("Fire", 2, 25);
    }

    /// <summary>
    /// add detials on ability then use it
    /// </summary>
    protected override void UseAbility()
    {
        if (IsValid() == false) return;

        CreateOneFire();
    }

    /// <summary>
    /// Create ammo
    /// </summary>
    private void CreateOneFire()
    {
        GameObject fire = Instantiate(ammoObj);
        fire.transform.position = shootCenter.position;
        fire.transform.rotation = shootCenter.rotation;
    }

    /// <summary>
    /// Cheack there was not any null reference 
    /// </summary>
    /// <returns></returns>
    private bool IsValid()
    {
        string errorMassage = "";

        if(shootCenter == null)
        {
            errorMassage += $"{this.name} : {shootCenter.name} is null \n";
        }

        if (ammoObj == null)
        {
            errorMassage += $"{this.name} : {ammoObj.name} is null \n";
        }

        if(errorMassage != "")
        {
            Debug.LogError(errorMassage);
            return false;
        }
        else
        {
            return true;
        }
    }

}
