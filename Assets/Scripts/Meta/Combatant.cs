using UnityEngine;

public class Combatant : Character
{
    public int maxHealth = 0;
    public int baseDamage = 0;
    public int baseArmor = 0;
    public int initiative = 0;

    public int currentHealth = 0;

    // Returns a percentage representation of health 
    public float HealthPercentage()
    {
        return (maxHealth - currentHealth) / maxHealth * 100;
    }

    public void TakeDamage(int damage)
    { // Damage received with reduction by armor
        if (damage < baseArmor) { return; }
        currentHealth -= damage - baseArmor;
        // TODO: Intergrate into UI for damage received indicator
    }

    public virtual void TurnAction()
    {
        Debug.Log("Not implemented");
    }
}
