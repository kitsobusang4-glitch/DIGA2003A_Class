using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public static event Action OnPlayerDeath;
    public static event Action OnEnemyDeath;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TextMeshProUGUI dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "The " + enemyUnit.unitName + " saw you leave. Now you must FIGHT";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(5f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()

    {
        dialogueText.text = "Choose an option";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(35);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "A sip of the medicine has healed you up!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    
    IEnumerator PlayerAttack()
    {
        state = BattleState.ENEMYTURN;
        // Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        playerPrefab.GetComponent<Animator>().Play("PunchPunch");
        dialogueText.text = "The attack is successful";
        

        yield return new WaitForSeconds(2f);

        // Check if the enemy is dead
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
            OnEnemyDeath?.Invoke();

            //end the battle
        } else
        {
            //enemy turn
            
            StartCoroutine(EnemyTurn());
        }

        
    }

    IEnumerator PlayerKick()
    {
        state = BattleState.ENEMYTURN;
        // Damage the enemy
        bool isDead = enemyUnit.TakeKickDamage(playerUnit.kickDamage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The kick attack is successful";

        yield return new WaitForSeconds(2f);

        // Check if the enemy is dead
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
            OnEnemyDeath?.Invoke();

            //end the battle
        }
        else
        {
            //enemy turn
            
            StartCoroutine(EnemyTurn());
        }

        // Change state based on what happened
    }

    public enum EnemyAttacks
    {
        Punch,
        kick,
    }
    IEnumerator EnemyTurn()
    {
        EnemyAttacks attacks = (EnemyAttacks)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(EnemyAttacks)).Length);
        if (attacks == EnemyAttacks.Punch)
        {

            dialogueText.text = "The " + enemyUnit.unitName + " punches!";
            playerUnit.currentHP -= enemyUnit.damage;
            yield return new WaitForSeconds(1f);

            playerHUD.SetHP(playerUnit.currentHP);

            yield return new WaitForSeconds(1f);
        }

        else if (attacks == EnemyAttacks.kick)
        {
            dialogueText.text = "The " + enemyUnit.unitName + " kicks!";
            playerUnit.currentHP -= enemyUnit.kickDamage;
            yield return new WaitForSeconds(1f);

            playerHUD.SetHP(playerUnit.currentHP);

        }
        yield return new WaitForSeconds(1f);
        
        bool isDead = playerUnit.currentHP <= 0;
        
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
            OnPlayerDeath?.Invoke();
        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You've beaten up the thug, you win!";
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "The thug has beaten you up, you lose!";
        }
    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnKickButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerKick());
    }
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
}

