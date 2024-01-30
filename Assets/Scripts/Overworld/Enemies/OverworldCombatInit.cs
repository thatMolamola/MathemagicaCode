using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCombatInit : MonoBehaviour
{
    public SceneControl sc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col) {
        StartCoroutine (BattleLaunch());
        
    }

    IEnumerator BattleLaunch() {

        yield return new WaitForSeconds(2f);
        sc.CombatSceneLoad("StaticCombat");
    }

}
