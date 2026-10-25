using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public Combatant owner;
    public Targetable target = Targetable.enemy; // Target selection
    public bool aoe = false; // Target all applicable targets
    public abstract void Act(Combatant targeted);
}

public enum Targetable
{
    ally,
    enemy
}