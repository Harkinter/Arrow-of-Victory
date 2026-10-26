using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Combatant))]
public class Action : MonoBehaviour
{
    private void Awake()
    {
        owner = GetComponent<Combatant>();
    }
    public Combatant owner;
    public List<Combatant> targets = new(4); // Pre-emptive capacity for usual maximum
    public virtual void Act()
    {
        // TODO: Add UI logic here
    }
}

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