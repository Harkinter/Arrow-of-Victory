using UnityEngine;

public enum ActionType
{
    attack,
    heal
}

public enum Targetable
{
    enemy,
    ally
}

[CreateAssetMenu(fileName = "Action", menuName = "Scriptable/Action", order = 2)]
public class Action : ScriptableObject
{
    public string _name;
    public int _power;
    public ActionType _actionType;
    public Targetable _targetable;
}
