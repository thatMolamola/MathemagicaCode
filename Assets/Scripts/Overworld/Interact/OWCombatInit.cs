using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWCombatInit : MonoBehaviour
{
    public SceneControl sc;

    public GameObject combatant;
    public CombatPrefabRefer combatantReference;


    // Start is called before the first frame update
    void Start()
    {
        combatantReference = Resources.Load<CombatPrefabRefer>("SOs/Dynamic/CombatRefer");
        combatant = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Player") {
            combatantReference.enemyRefer = combatant.GetComponent<EnemyUnit>().unitPrefab;
            StartCoroutine (BattleLaunch());
        }
    }

    IEnumerator BattleLaunch() {

        yield return new WaitForSeconds(2f);
        sc.CombatSceneLoad("StaticCombat");
        Destroy(this.gameObject);
    }

}
