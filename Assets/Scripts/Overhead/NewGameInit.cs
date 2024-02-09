using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameInit : MonoBehaviour
{
    [SerializeField] CombatPrefabRefer dynamicTeamState;
    [SerializeField] Inventory dynamicInvState;
    [SerializeField] CombatPrefabRefer staticTeamState;
    [SerializeField] Inventory staticInvState;

    [SerializeField] WeaponItem[] _defaults;
    [SerializeField] WeaponItem[] _targets;

    public void onNewGame() {
        dynamicTeamState.allyTeam = staticTeamState.allyTeam;
        dynamicInvState.NPItemCounts = staticInvState.NPItemCounts;
        dynamicInvState.NPItemsIndex = staticInvState.NPItemsIndex;
        dynamicInvState.KeyItems = staticInvState.KeyItems;
        weaponReset();
    }

    private void weaponReset() {
        for (int i = 0; i < _defaults.Length; i++){
            if (_defaults[i] != null) {
                var jsonData = JsonUtility.ToJson(_defaults[i]);
                JsonUtility.FromJsonOverwrite(jsonData, _targets[i]);
            }
        }
    }
}