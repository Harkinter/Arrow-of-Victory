using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; } // Single-existent instance
    public List<EntityCombatant> _inFight = new(8);
    public GameObject _combatantSlate;
    private static int _nextInOrder = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else Destroy(gameObject); // No duplicates
    }

    private void Start()
    {
#if DEBUG // Testing object creation
        List<Combatant> combatants = new()
        {
            ScriptableObject.CreateInstance<Combatant>()
        };
        StartCombat(combatants);
#endif
    }

    public void NextTurn()
    {
        if (_nextInOrder > _inFight.Count - 1) _nextInOrder = 0;
        _inFight[_nextInOrder]._turn.Act();
        _nextInOrder++;
    }

    public void RefreshInitiative()
    {
        _inFight.OrderBy(o => o._baseCombatant._initiative);
    }

    public void StartCombat(List<Combatant> combatants)
    {
        EntityCombatant entityOfCombatant = (EntityCombatant)Instantiate(_combatantSlate).AddComponent(typeof(EntityCombatant));
        entityOfCombatant._baseCombatant = combatants[0];
    }

    public void EndCombat()
    {
        _inFight.Clear();
    }
}
