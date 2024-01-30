using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERT, ENEMYT, WON, LOST, FLED, WAITING}

public class BattleSystem : MonoBehaviour
{
    public SceneControl sc;

    //state change variables
    public BattleState state; 

    //battle unit variables
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerLoc;
    public Transform enemyLoc;

    PlayerUnit playerUnit;
    EnemyUnit enemyUnit;

    private CombatPrefabRefer combatantReference;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    //text display variables
    public Text dialogueText;

    //typing letter by letter variables
    //public bool isTyping;
    //public int maxVisibleChars;
    

    void Start()
    {
        state = BattleState.START;
        combatantReference = Resources.Load<CombatPrefabRefer>("SOs/CombatRefer");
        enemyPrefab = combatantReference.enemyRefer;
        StartCoroutine(SetupBattle());
    }

    // Instantiation and Set Up Coroutine
    IEnumerator SetupBattle()
    {
        GameObject playGO = Instantiate(playerPrefab, playerLoc);
        playerUnit = playGO.GetComponent<PlayerUnit>();
        GameObject enGO = Instantiate(enemyPrefab, enemyLoc);
        enemyUnit = enGO.GetComponent<EnemyUnit>();

        dialogueText.text = "From the shadows, a " + enemyUnit.unitName + " has emerged!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state= BattleState.PLAYERT;
        PlayerTurn();
    }

    // PLAYER TURN OPTIONS 
    void PlayerTurn() {
        dialogueText.text = "Choose an action!";
    }

    //ATTACK
    public void OnWeaponButton(int weaponNum) {
        if (state != BattleState.PLAYERT) {
            return;
        }
        playerUnit.selectedWeapon = weaponNum;
        StartCoroutine (PlayerAttack());
    }

    IEnumerator PlayerAttack() {
        state = BattleState.WAITING;
        bool isDead = playerUnit.selectedWeaponAttack(enemyUnit);
        // Update VisualDamage to Enemy
        enemyHUD.SetHP(enemyUnit.currentHPReal);
        enemyHUD.HPSliderAngle(enemyUnit);

        yield return new WaitForSeconds(2f);

        if (isDead) {
            state = BattleState.WON;
            EndBattle();
        } else {
            state = BattleState.ENEMYT;
            StartCoroutine(EnemyTurn());
        }
    }

    //CRAFT
    public void OnCraftButton() {
        if (state != BattleState.PLAYERT) {
            return;
        }
        StartCoroutine (PlayerCraft());
    }

    IEnumerator PlayerCraft() {
        yield return new WaitForSeconds(2f);

        StartCoroutine(EnemyTurn());
        }
    

    //FLEE
    public void OnFleeButton() {
        if (state != BattleState.PLAYERT) {
            return;
        }
        StartCoroutine (PlayerFlee());
    }

    IEnumerator PlayerFlee() {
        //Flee probability
        dialogueText.text = "It's too soon to run away!";
        yield return new WaitForSeconds(2f);

        StartCoroutine(EnemyTurn());
    }

    //ENEMY OPTIONS
    IEnumerator EnemyTurn() {
        state = BattleState.WAITING;
        dialogueText.text = enemyUnit.unitName + " attacks!"; 

        yield return new WaitForSeconds(2f);
        bool isDead = false;
        if (enemyUnit.numTurnsLeftSpecial == 0) {
            isDead = enemyUnit.specialAttack(playerUnit);
        } else {
            isDead = enemyUnit.standardAttack(playerUnit);
        }

        if (enemyUnit.numTurnsLeftStandardTwo == 0) {
            dialogueText.text = enemyUnit.secondStandardAttack(enemyUnit);
        } 

        playerHUD.SetHP(playerUnit.currentHPReal);
        playerHUD.HPSliderAngle(playerUnit);


        yield return new WaitForSeconds(2f);

        if (isDead) {
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERT;
            PlayerTurn();
        }
    }

    //End Battle Conditions
    void EndBattle() {
        if (state == BattleState.WON) {
            dialogueText.text = "You won the Battle!";
        } else if (state == BattleState.LOST) {
            dialogueText.text = "You lost the Battle...";
        } else if (state == BattleState.FLED) {
            dialogueText.text = "You fled the Battle...";
        }
        sc.CombatSceneUnload();
    }
    /*
    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;

        int maxVisibleChars = 0;

        NPCDialogueText.text = p;
        NPCDialogueText.maxVisibleCharacters = maxVisibleChars;        

        foreach (char c in p.ToCharArray())
        {

            maxVisibleChars++;
            NPCDialogueText.maxVisibleCharacters = maxVisibleChars;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }

        isTyping = false;
    }
    */
}

