using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OWKeyCombat : OWInteract
{
    [SerializeField] private int KeyItemNumCheck;
    [SerializeField] private CombatPrefabRefer CPR;
    [SerializeField] private Inventory playerInv;
    [SerializeField] private SceneControl sc;
    [SerializeField] private GameObject combatant1, combatant2;

    public override void Interact() {
        if (playerInv.KeyItems.Contains(KeyItemNumCheck)) {
            CPR.enemyRefer = combatant2.GetComponent<EnemyUnit>().unitPrefab;
            StartCoroutine (BattleLaunch());
        } else {
            CPR.enemyRefer = combatant1.GetComponent<EnemyUnit>().unitPrefab;
            sc.CombatSceneLoad("StaticCombat");
        }
    }

    public IEnumerator BattleLaunch() {
        yield return new WaitForSeconds(2f);
        sc.CombatSceneLoad("StaticCombat");
        Destroy(this.gameObject);
    }
}
