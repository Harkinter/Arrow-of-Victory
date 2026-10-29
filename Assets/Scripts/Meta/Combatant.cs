using UnityEngine;

public class Combatant
{
    public int maxHealth = 0;
    public int baseDamage = 0;
    public int baseArmor = 0;
    public int initiative = 0;
    public Faction faction = Faction.player;
    public Action[] actions = new Action[6];

    public ITurn turnInterface; // Used to connect to either player control or code-based intelligence

    public int currentHealth = 0;
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

    public void TakeTrue(int amount)
    {
        if (currentHealth + amount > maxHealth) { currentHealth = maxHealth; }
        else { currentHealth += amount; }
    }
}

public enum Faction
{
    player,
    enemy
}