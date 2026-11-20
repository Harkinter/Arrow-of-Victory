
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combatant", menuName = "Scriptable/Combatant", order = 1)]
public class Combatant : ScriptableObject
{
    public int _maxHealth;
    public int _defense;
    public int _initiative;
    public List<Action> _actions;
}
