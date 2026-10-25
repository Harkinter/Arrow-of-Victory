using UnityEngine;

public class Attack : Action
{
    public override void Act(Combatant targeted)
    {
        targeted.TakeDamage(owner.baseDamage);
    }
}
