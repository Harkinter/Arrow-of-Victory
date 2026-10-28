using System.Collections.Generic;
using System.Linq;

public static class CombatManager
{
    // Static to carry information between combat theather and overworld
    public static List<Combatant> turnRotation = new();
    private static int orderPos;
    public static void SelectForTurn()
    {
        if (orderPos > turnRotation.Count)
        {
            orderPos = 0;
        }
        turnRotation[orderPos].turnInterface.TakeTurn();
        orderPos++;
    }
    public static void UpdateRotation()
    {
        turnRotation.OrderBy(o => o.initiative);
    }
}
