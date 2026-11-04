public enum ActionType
{
    attack,
    heal,
    damage
}

public enum Targetable
{
    enemy,
    ally
}

public struct Action
{
    public string _name;
    public int _power;
    public ActionType _actionType;
    public Targetable _targetable;
}
