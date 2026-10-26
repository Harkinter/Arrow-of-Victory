public class Attack : Action
{
    public override void Act()
    {
        foreach (Combatant target in targets)
        {
            target.TakeDamage(owner.baseDamage);
        }
    }
}
