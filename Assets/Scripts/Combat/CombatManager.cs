using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static List<Combatant> combatants = new();
    private int orderPos;
    public void SelectForTurn()
    {
        if (orderPos > combatants.Count)
        {
            orderPos = 0;
        }
        combatants[orderPos].turnInterface.TakeTurn();
        orderPos++;
    }
    public void UpdateRotation()
    {
        combatants.OrderBy(o => o.initiative);
    }
}
