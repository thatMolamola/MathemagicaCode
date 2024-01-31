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
    public GameObject[] playerTeamPrefabs;
    public GameObject enemyPrefab;

    public Transform[] playerLocs;
    public Transform enemyLoc;

    List<PlayerUnit> playerUnits;
    EnemyUnit enemyUnit;

    private CombatPrefabRefer combatantReference;

    public BattleHUD[] playerHUDs;
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
        playerTeamPrefabs = combatantReference.allyTeam;
        enemyPrefab = combatantReference.enemyRefer;
        StartCoroutine(SetupBattle());
    }

    // Instantiation and Set Up Coroutine
    IEnumerator SetupBattle()
    {
        List<PlayerUnit> playerUnits = new List<PlayerUnit>();
        int playerCount = 0;
        foreach (var playerPrefab in playerTeamPrefabs) {
            GameObject playGO = Instantiate(playerPrefab, playerLocs[playerCount]);
            playerCount += 1;
            playerUnits.Add(playGO.GetComponent<PlayerUnit>());
        }
        
        GameObject enGO = Instantiate(enemyPrefab, enemyLoc);
        enemyUnit = enGO.GetComponent<EnemyUnit>();

        dialogueText.text = "From the shadows, a " + enemyUnit.unitName + " has emerged!";

        playerCount = 0;
        foreach (var allyUnit in playerUnits) {
            playerHUDs[playerCount].gameObject.SetActive(true);
            playerHUDs[playerCount].SetHUD(allyUnit);
            playerCount += 1; 
        }

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
        int playerNum = 1;
        playerUnits[playerNum].selectedWeapon = weaponNum;
        StartCoroutine (PlayerAttack(playerUnits[playerNum]));
    }

    IEnumerator PlayerAttack(PlayerUnit playerUnit) {
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
        int randNum = Random.Range(0, 2);
        PlayerUnit playerUnit = playerUnits[randNum];
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

        playerHUDs[randNum].SetHP(playerUnit.currentHPReal);
        playerHUDs[randNum].HPSliderAngle(playerUnit);


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

