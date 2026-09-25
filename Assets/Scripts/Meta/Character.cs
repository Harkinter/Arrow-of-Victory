using UnityEngine;

public class Character : MonoBehaviour
{
    // - Modifiers -
    public string Name = "";
    public int MaxHealth = 0;
    public int BaseDamage = 0;
    public int BaseArmor = 0;
    public int Initiative = 0;

    // - Variables -
    public int Health = 0;

    // - Functions -
    public float HealthPercentage()
    { // Returns a percentage representation of health 
        return (MaxHealth - Health) / MaxHealth * 100; 
    }
    public void TakeDamage(int damage)
    { // Damage received with reduction by armor
        if (damage < BaseArmor) { return; }
        Health -= damage - BaseArmor; 
        // TODO: Intergrate into UI for damage received indicator
    }

}
