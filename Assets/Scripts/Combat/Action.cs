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