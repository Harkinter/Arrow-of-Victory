using UnityEngine;

public class EntityCombatant : MonoBehaviour
{
    public Combatant _baseCombatant;
    public int _currentHealth;

    private void Start()
    {
        _currentHealth = _baseCombatant._maxHealth;
    }
}
