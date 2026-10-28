using UnityEngine;
public class Restore : Action
{
    // Technically also "true damage" if made negative
    [SerializeField] private int healing = 0;
    public override void Act()
    {
        foreach (Combatant target in targets)
        {
            target.TakeHealing(healing);
        }
    }
}
