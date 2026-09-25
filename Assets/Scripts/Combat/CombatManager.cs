using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // TODO: Implement combat entities
    public List<Character> Enemy = new(); // Reference list for enemies in battle
    public List<Character> Allies = new(); // Reference list for allies in battle
    public List<Character> TurnRotation = new(); // Reference list for rotation of turns
    
    public void TurnAccess()
    {

    }
    public void UpdateTurns()
    {
        foreach (Character character in TurnRotation) 
        { 

        }
    }
}
