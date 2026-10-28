using UnityEngine;
public class Damage : Action
{
    [SerializeField] private int damage = 0;
    public override void Act()
    {
        foreach (Combatant target in targets)
        {
            target.TakeDamage(damage);
        }
    }
}
