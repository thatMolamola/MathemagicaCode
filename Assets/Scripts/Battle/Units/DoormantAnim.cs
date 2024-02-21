using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoormantAnim : MonoBehaviour
{
    [SerializeField] Animator doormantAnim;

    void Update() {
        if (this.gameObject.GetComponent<EnemyUnit>().thisUnit.currentHPReal < 1000) {
            doormantAnim.SetBool("Awoken", true);
        }
    }
}
