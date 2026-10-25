using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Combatant> turnRotation = new(); // Rotation of turn attackers
    private int orderPos;
    
    public void SelectForTurn()
    {
        if (orderPos > turnRotation.Count)
        {
            orderPos = 0;
            
        }
        turnRotation[orderPos].TurnAction();
        orderPos++;
    }
    public void UpdateRotation()
    {
        turnRotation.OrderBy(o => o.initiative);
    }
}
