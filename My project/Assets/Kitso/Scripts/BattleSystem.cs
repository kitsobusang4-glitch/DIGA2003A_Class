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
    AudioSource audioSource;
    Unit playerUnit;
    Unit enemyUnit;

    public TextMeshProUGUI dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    public Animator enemyAnimator;
    public AudioClip enemyPunchSFX;
    public AudioClip enemyKickSFX;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        audioSource = GetComponent<AudioSource>();
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

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()

    {
        dialogueText.text = "Choose an option";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(50);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "A sip of the medicine has healed you up!";

        yield return new WaitForSeconds(1f);

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
        

        yield return new WaitForSeconds(1f);

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
        playerPrefab.GetComponent<Animator>().Play("PlayerKick");
        dialogueText.text = "The kick attack is successful";

        yield return new WaitForSeconds(1f);

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
            enemyAnimator.SetTrigger("EnemyPunch");

            // Plays SFX from code when the trigger is set.
            if (audioSource != null && enemyPunchSFX != null)
            {
                audioSource.PlayOneShot(enemyPunchSFX);
            }

            yield return new WaitForSeconds(1f);

            enemyAnimator.SetTrigger("EnemyIdle");
            dialogueText.text = "The " + enemyUnit.unitName + " punches!";
            playerUnit.currentHP -= enemyUnit.damage;
            yield return new WaitForSeconds(1f);

            playerHUD.SetHP(playerUnit.currentHP);

            yield return new WaitForSeconds(1f);
        }

        else if (attacks == EnemyAttacks.kick)
        {
            enemyAnimator.SetTrigger("EnemyKick");

        
            if (audioSource != null && enemyKickSFX != null)
            {
                audioSource.PlayOneShot(enemyKickSFX);
            }

            yield return new WaitForSeconds(1f);

            enemyAnimator.SetTrigger("EnemyIdle");

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

    
    
    public void PlayEnemyPunchSFX()
    {
        if (audioSource != null && enemyPunchSFX != null)
            audioSource.PlayOneShot(enemyPunchSFX);
    }

    public void PlayEnemyKickSFX()
    {
        if (audioSource != null && enemyKickSFX != null)
            audioSource.PlayOneShot(enemyKickSFX);
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


    IEnumerator Delayer()
    {
        yield return new WaitForSeconds(4f);
    }
}

