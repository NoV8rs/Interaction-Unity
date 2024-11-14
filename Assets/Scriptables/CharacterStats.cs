using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Stats/CharacterStats", order = 1)]
public class CharacterStats : ScriptableObject
{
    public string characterName;
    
    public void PrintStats()
    {
        Debug.Log("Character Name: " + characterName);
    }
}
