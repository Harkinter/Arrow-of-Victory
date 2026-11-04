using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<EntityCombatant> inFight;

    private int nextInOrder = 0;
    public void NextTurn()
    {
        if (nextInOrder > inFight.Count - 1) nextInOrder = 0;
        
        nextInOrder++;
    }
    public void RefreshInitiative()
    {
        inFight.OrderBy(o => o._baseCombatant._initiative);
    }

    private void BeginTurn(EntityCombatant activeCombatant)
    {
        // TODO : Implement combat controls for AI and Player
    }
}
