using UnityEngine;

public class Combatant : Character
{
    public int maxHealth = 0;
    public int baseDamage = 0;
    public int baseArmor = 0;
    public int initiative = 0;

    [HideInInspector] public int currentHealth = 0;

    public Action[] actions = new Action[6];

    // Returns a percentage representation of health 
    public float HealthPercentage()
    {
        return (maxHealth - currentHealth) / maxHealth * 100;
    }

    public void TakeDamage(int damage)
    {
        if (damage < baseArmor) { Debug.Log("Damage fully nullified"); }
        else { currentHealth -= damage - baseArmor; }
    }

    public void TakeHealing(int heal)
    {
        if (currentHealth + heal > maxHealth) { currentHealth = maxHealth; } // No overheal
        else { currentHealth += heal; }
    }

    public virtual void TurnAction()
    {
        Debug.Log("Not implemented");
    }
}
