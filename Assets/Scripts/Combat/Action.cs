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
    public virtual void Act()
    {
        // TODO: Add UI logic here
    }
}