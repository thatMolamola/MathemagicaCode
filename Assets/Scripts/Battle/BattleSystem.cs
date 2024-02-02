using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERT, ENEMYT, WON, LOST, FLED, WAITING}

public class BattleSystem : MonoBehaviour
{
    //playerside variables
    [SerializeField] private GameObject[] playerTeamPrefabs;
    [SerializeField] private Transform[] playerLocs;
    [SerializeField] private GameObject buttonsAccess;
    [SerializeField] private List<PlayerUnit> playerUnits = new List<PlayerUnit>();
    [SerializeField] private BattleHUD[] playerHUDs;
    [SerializeField] private AttackMenu[] attackSets;

    //Enemyside references
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemyLoc;
    [SerializeField] private EnemyUnit enemyUnit;
    [SerializeField] private BattleHUD enemyHUD;

    //state change variables
    [SerializeField] private SceneControl sc;
    public BattleState state; 
    public Queue<Action> actionQueue = new Queue<Action>();
    private Action currentAction;
    private Queue<string> weaponQueue = new Queue<string>();
    [SerializeField] private Text dialogueText;   
    

    void Start()
    {
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
    IEnumerator SetupBattle()
    {
        int playerCount = 0;
        //For every member on the player team, instantiate them and add them to the list
        foreach (var playerPrefab in playerTeamPrefabs) {
            GameObject playGO = Instantiate(playerPrefab, playerLocs[playerCount]);
            playerCount += 1;
            playerUnits.Add(playGO.GetComponent<PlayerUnit>());
        }
        
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
            attackSets[playerCount].characterWeapons = allyUnit.weaponList;
            playerCount += 1; 
        }

        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERT;
        PlayerTurn();
    }

    // PLAYER TURN OPTIONS 
    void PlayerTurn() {
        dialogueText.text = "Choose an action!"; 
    }

    public void onAttackButton(int weaponNum){
        int playerNum = actionQueue.Count;
        Action currentAction = new Action(playerUnits[playerNum].weaponList[weaponNum], enemyUnit, "ATTACK");
        actionQueue.Enqueue(currentAction);
        OnActionButton();
    }

    public void onCraftButton(int weaponNum){
        int playerNum = actionQueue.Count;
        Action currentAction = new Action(playerUnits[playerNum].weaponList[weaponNum], null, "CRAFT");
        actionQueue.Enqueue(currentAction);
        OnActionButton();
    }

    public void onFleeButton(){
        Action currentAction = new Action(null, null, "FLEE");
        actionQueue.Enqueue(currentAction);
        OnActionButton();
    }

    //All options lead to the OnActionButton, which counts the actions and starts the execution once ready
    public void OnActionButton() {
        //Weapon weaponChoice, int target, string actionCategory
        if (state != BattleState.PLAYERT) {
            return;
        }

        if (actionQueue.Count == playerUnits.Count) {
            StartCoroutine (PlayerActs());
        } 
    }

    IEnumerator PlayerActs() {
        state = BattleState.WAITING;
        yield return new WaitForSeconds(1f);
        int queueCounter = 0;
        while (actionQueue.Count != 0) {
            float oldRealHP = enemyUnit.currentHPReal;
            float oldImagHP = enemyUnit.currentHPImag;

            int damageDone = playerUnits[queueCounter].executeAction(actionQueue.Dequeue());
            bool isDead = playerUnits[queueCounter].deathCheck(enemyUnit);
            
            // Update VisualDamage to Enemy
            enemyHUD.SetHP(enemyUnit.currentHPReal);
            enemyHUD.HPSliderAngle(enemyUnit);

            Debug.Log(damageDone);
            if (damageDone != 0) {
                dialogueText.text = enemyUnit.unitName + " took " + (oldRealHP - enemyUnit.currentHPReal) + " damage from " + playerUnits[queueCounter].unitName + "!";
            }
            
            queueCounter += 1;
            yield return new WaitForSeconds(2f);

            if (isDead) {
                state = BattleState.WON;
                StartCoroutine(EndBattle());
                yield break;
            } 

            if (oldRealHP > 0) {
                if (enemyUnit.currentHPReal < 0) {
                    Debug.Log("flip triggered");
                    enemyLoc.GetComponent<Animator>().Play("flipSprite",  -1, 0f);
                    enemyUnit.animChange();
                    dialogueText.text = "The " + enemyUnit.unitName + " grew enraged!";
                    yield return new WaitForSeconds(1f);
                }
            } else if (oldRealHP < 0) {
                if (enemyUnit.currentHPReal > 0) {
                    enemyLoc.GetComponent<Animator>().Play("flipSprite",  -1, 0f);
                    enemyUnit.animChange();
                    dialogueText.text = "The " + enemyUnit.unitName + " grew enraged!";
                    yield return new WaitForSeconds(1f);
                }
            } 
        }
        state = BattleState.ENEMYT;
        StartCoroutine(EnemyTurn());
    }

    //ENEMY OPTIONS
    IEnumerator EnemyTurn() {
        int randNum = Random.Range(0, playerUnits.Count);
        PlayerUnit playerUnit = playerUnits[randNum];
        state = BattleState.WAITING;
        dialogueText.text = enemyUnit.unitName + " attacks!"; 
        
        if (playerUnits.Count > 1) {
            randNum = 1 - randNum;
            playerHUDs[randNum].setTop(playerHUDs[randNum].transform);
            randNum = 1 - randNum;
        }

        yield return new WaitForSeconds(.5f);
        
        bool isDead = false;
        if (enemyUnit.numTurnsLeftSpecial == 0) {
            isDead = enemyUnit.specialAttack(playerUnit);
        } else {
            isDead = enemyUnit.standardAttack(playerUnit);
        }
        dialogueText.text = playerUnit.unitName + " took damage from " + enemyUnit.unitName + "!";


        //if (enemyUnit.numTurnsLeftStandardTwo == 0) {
        //    dialogueText.text = enemyUnit.secondStandardAttack(enemyUnit);
        //} 

        
        playerHUDs[randNum].SetHP(playerUnit.currentHPReal);
        playerHUDs[randNum].HPSliderAngle(playerUnit);


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
    IEnumerator EndBattle() {
        if (state == BattleState.WON) {
            dialogueText.text = "You won the Battle!";
            //add battle reward items to inventory
        } else if (state == BattleState.LOST) {
            dialogueText.text = "You lost the Battle...";
        } else if (state == BattleState.FLED) {
            dialogueText.text = "You fled the Battle...";
        }
        yield return new WaitForSeconds(2f);
        sc.CombatSceneUnload();
    }
}

