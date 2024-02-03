using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "combatRefer", menuName = "Data Storage/Combat")]
public class CombatPrefabRefer : ScriptableObject
{
    public GameObject enemyRefer;
    public GameObject[] allyTeam; 
}
