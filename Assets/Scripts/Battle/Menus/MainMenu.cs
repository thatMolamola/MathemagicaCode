using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BattleSystem system;

    public void onAttackPress() {
        if (system.actionQueue.Count == 0) {
            onAttack1Press();
        } else {
            onAttack2Press();
        }
    }

    public void onAttack1Press() {
       MenuManage.OpenMenu(Menu.ATTACK1, gameObject);
    }

    public void onAttack2Press() {
       MenuManage.OpenMenu(Menu.ATTACK2, gameObject);
    }

    public void onEnchantPress() {
        if (system.actionQueue.Count == 0) {
            onEnchant1Press();
        } else {
            onEnchant2Press();
        }
    }

    public void onEnchant1Press() {
        MenuManage.OpenMenu(Menu.ENCHANT1, gameObject);
    }

    public void onEnchant2Press() {
        MenuManage.OpenMenu(Menu.ENCHANT2, gameObject);
    }
}

