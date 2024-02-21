using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameInit : MonoBehaviour
{
    [SerializeField] private CombatPrefabRefer dynamicTeamState;
    [SerializeField] private Inventory dynamicInvState;
    [SerializeField] private CombatPrefabRefer staticTeamState;
    [SerializeField] private Inventory staticInvState;

    [SerializeField] private WeaponItem[] _defaultW;
    [SerializeField] private WeaponItem[] _targetW;

    [SerializeField] private UnitData[] _targetP;

    [SerializeField] private UnitData[] _defaultP;



    public void onNewGame() {
        dynamicTeamState.allyTeam = staticTeamState.allyTeam;
        dynamicInvState.NPItemCounts = staticInvState.NPItemCounts;
        dynamicInvState.NPItemsIndex = staticInvState.NPItemsIndex;
        dynamicInvState.KeyItems = staticInvState.KeyItems;
        weaponReset();
        playersReset();
    }

    private void weaponReset() {
        for (int i = 0; i < _defaultW.Length; i++){
            if (_defaultW[i] != null) {
                var jsonData = JsonUtility.ToJson(_defaultW[i]);
                JsonUtility.FromJsonOverwrite(jsonData, _targetW[i]);
            }
        }
    }

    private void playersReset() {
        for (int i = 0; i < _defaultP.Length; i++){
            if (_defaultP[i] != null) {
                var jsonData = JsonUtility.ToJson(_defaultP[i]);
                JsonUtility.FromJsonOverwrite(jsonData, _targetP[i]);
            }
        }
    }
}