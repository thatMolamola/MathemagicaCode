using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameInit : MonoBehaviour
{
    [SerializeField] CombatPrefabRefer dynamicTeamState;
    [SerializeField] Inventory dynamicInvState;
    [SerializeField] CombatPrefabRefer staticTeamState;
    [SerializeField] Inventory staticInvState;

    public void onNewGame() {
        dynamicTeamState.allyTeam = staticTeamState.allyTeam;
        dynamicInvState.NPItemCounts = staticInvState.NPItemCounts;
        dynamicInvState.NPItemsIndex = staticInvState.NPItemsIndex;
        dynamicInvState.KeyItems = staticInvState.KeyItems;
    }
}
