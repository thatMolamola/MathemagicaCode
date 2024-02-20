using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERT, ENEMYT, WON, LOST, FLED, WAITING}

public class BattleSystem : MonoBehaviour
{
    //playerside variables
    private List<GameObject> playerTeamPrefabs = new List<GameObject>();
    [SerializeField] private Transform[] playerLocs;
    [SerializeField] private GameObject buttonsAccess;
    [SerializeField] private List<PlayerUnit> playerUnits = new List<PlayerUnit>();
    [SerializeField] private BattleHUD[] playerHUDs;
    [SerializeField] private AttackMenu[] attackSets;
    [SerializeField] private EnchantPanel enchantPanel;
    [SerializeField] private RewardsMenu onWinRewards;

    //Enemyside references
    private GameObject enemyPrefab;
    [SerializeField] private Transform enemyLoc;
    [SerializeField] private EnemyUnit enemyUnit;
    [SerializeField] private BattleHUD enemyHUD;

    //state change variables
    [SerializeField] private SceneControl sc;
    public BattleState state; 
    public Queue<Action> actionQueue = new Queue<Action>();
    private Action currentAction;

    private ActionResponse currentResponse;
    private Queue<string> weaponQueue = new Queue<string>();
    [SerializeField] private Text dialogueText;   
    private CombatPrefabRefer combatantReference;
    

    void Start()
    {
        combatantReference = Resources.Load<CombatPrefabRefer>("SOs/Dynamic/CombatRefer");
        playerTeamPrefabs = combatantReference.allyTeam;
        enemyPrefab = combatantReference.enemyRefer;
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    void Update() {
        if (state != BattleState.PLAYERT) {
            buttonsAccess.SetActive(false);
        } else {
            buttonsAccess.SetActive(true);
        }
    }

    // Instantiation and Set Up Coroutine
    private IEnumerator SetupBattle()
    {
        int playerCount = 0;
        
        //For every member on the player team, instantiate them and add them to the list
        foreach (var playerPrefab in playerTeamPrefabs) {
            GameObject playGO = Instantiate(playerPrefab, playerLocs[playerCount]);
            playerCount += 1;
            playerUnits.Add(playGO.GetComponent<PlayerUnit>());
        }
        
        //Offset to allow for the sprite flipping
        Vector3 offset = new Vector3(0f, .5f, 0f);
        GameObject enGO = Instantiate(enemyPrefab, enemyLoc);
        
        enGO.transform.position += offset;
        enemyUnit = enGO.GetComponent<EnemyUnit>();

        dialogueText.text = "From the shadows, a " + enemyUnit.unitName + " has emerged!";


        playerCount = 0;
        //for every member on the player team, set their HUD's data
        foreach (var allyUnit in playerUnits) {
            playerHUDs[playerCount].gameObject.SetActive(true);
            playerHUDs[playerCount].SetHUD(allyUnit);
            attackSets[playerCount].characterWeapons = allyUnit.getWeaponList();
            playerCount += 1; 
        }

        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERT;
        PlayerTurn();
    }

    // PLAYER TURN OPTIONS 
    private void PlayerTurn() {
        dialogueText.text = "Choose an action!"; 
    }

    public void onAttackButton(int weaponNum){
        int playerNum = actionQueue.Count;
        Action currentAction = new Action(playerUnits[playerNum].getWeaponList()[weaponNum], enemyUnit, "ATTACK");
        actionQueue.Enqueue(currentAction);
        OnActionButton();
    }

    public void onEnchantButton(){
        int playerNum = actionQueue.Count;
        playerUnits[playerNum].setItem(enchantPanel.getItem());  
        Action currentAction = new Action(enchantPanel.getWeapon(), playerUnits[playerNum], "ENCHANT");
        actionQueue.Enqueue(currentAction);
        OnActionButton();
    }

    public void onFleeButton(){
        Action currentAction = new Action(null, enemyUnit, "FLEE");
        actionQueue.Enqueue(currentAction);
        OnActionButton();
    }

    //All options lead to the OnActionButton, which counts the actions and starts the execution once ready
    private void OnActionButton() {
        //Format of Weapon weaponChoice, int target, string actionCategory
        if (state != BattleState.PLAYERT) {
            return;
        }

        if (actionQueue.Count == playerUnits.Count) {
            StartCoroutine (PlayerActs());
        } 
    }

    private IEnumerator PlayerActs() {
        state = BattleState.WAITING;
        yield return new WaitForSeconds(1f);
        int queueCounter = 0;
        while (actionQueue.Count != 0) {
            currentResponse = playerUnits[queueCounter].executeAction(actionQueue.Dequeue());
            bool success = currentResponse.getSuccess();
            string action = currentResponse.getAction().getAction();
            
            // Update VisualDamage to Enemy
            enemyHUD.SetHUD(enemyUnit);
            dialogueText.text = currentResponse.getDialogue();
            queueCounter += 1;
            yield return new WaitForSeconds(2f);

            if (success) {
                if (action == "ATTACK") {
                    state = BattleState.WON;
                    StartCoroutine(EndBattle());
                } else if (action == "FLEE") {
                    state = BattleState.FLED;
                    StartCoroutine(EndBattle());
                }
            }
        } //Queue Loop End
        state = BattleState.ENEMYT;
        StartCoroutine(EnemyTurn());
    }

    //ENEMY OPTIONS
    private IEnumerator EnemyTurn() {
        state = BattleState.WAITING;
        int randNum = Random.Range(0, playerUnits.Count);
        PlayerUnit playerUnit = playerUnits[randNum];
        dialogueText.text = enemyUnit.unitName + " attacks!"; 
        
        if (playerUnits.Count > 1) {
            randNum = 1 - randNum;
            playerHUDs[randNum].setTop(playerHUDs[randNum].transform);
            randNum = 1 - randNum;
        }

        yield return new WaitForSeconds(.5f);

        float oldRealHP = playerUnit.currentHPReal;
        float oldImagHP = playerUnit.currentHPImag;
        bool isDead = false;

        if (enemyUnit.numTurnsLeftSpecial == 0) {
            isDead = enemyUnit.specialAttack(playerUnit);
        } else {
            isDead = enemyUnit.standardAttack(playerUnit);
        }

        float damageDone = oldRealHP - playerUnit.currentHPReal;
        if (damageDone != 0) {
            dialogueText.text = playerUnit.unitName + " took " + (Mathf.Round(damageDone*1000)/1000) + " damage from " + enemyUnit.unitName + "!";
        }

        if (enemyUnit.numTurnsLeftStandardTwo == 0) {
            dialogueText.text = enemyUnit.secondStandardAttack(enemyUnit);
            enemyUnit.numTurnsLeftStandardTwo = enemyUnit.numTurnsToStandardTwo;
        } 

        playerHUDs[randNum].SetHUD(playerUnit);

        yield return new WaitForSeconds(2f);

        if (isDead) {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        } else {
            state = BattleState.PLAYERT;
            PlayerTurn();
        }
    }

    //End Battle Conditions
    private IEnumerator EndBattle() {
        if (state == BattleState.WON) {
            dialogueText.text = "You won the Battle!";
            onWinRewards.displayRewards(enemyUnit);
            yield return new WaitForSeconds(2f);
            onWinRewards.onLeave();
            //add battle reward items to inventory
        } else if (state == BattleState.LOST) {
            dialogueText.text = "You lost the Battle...";
            yield return new WaitForSeconds(2f);
            sc.SceneLoad("MMMenu");
        } else if (state == BattleState.FLED) {
            dialogueText.text = "You fled the Battle...";
        }
        yield return new WaitForSeconds(2f);
        sc.CombatSceneUnload();
    }
}