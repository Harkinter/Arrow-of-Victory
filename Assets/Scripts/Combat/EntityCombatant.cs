using UnityEngine;

public class EntityCombatant : MonoBehaviour
{
    public TurnInterface _turn;
    public Combatant _baseCombatant;
    public int _currentHealth;

    private void Start()
    {
        _currentHealth = _baseCombatant._maxHealth;
    }
}
