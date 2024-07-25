using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    private enum BattleState { IntroStage, PlayerTurn, EnemyTurn, EndTurn, OutroStage, BattleOver }
    private BattleState currentBattleState;
    [SerializeField] 
    private BattleUIManager battleUIManager;
    private int tempPlayerValue = 0;
    private int tempEnemyValue = 0;
    //private bool victory = false;
    //private bool defeat = false;
    private bool isPlayerActionCompleted = false;
    private bool isEnemyActionCompleted = false;
    
    void Start()
    {
        currentBattleState = BattleState.IntroStage;
        StartCoroutine(BattleLoop());
    }

    private IEnumerator BattleLoop()
    {
        while (currentBattleState != BattleState.BattleOver)
        {
            switch (currentBattleState)
            {
                case BattleState.IntroStage:
                    yield return StartCoroutine(IntroStage());
                    break;
                case BattleState.PlayerTurn:
                    yield return StartCoroutine(PlayerTurn());
                    break;
                case BattleState.EnemyTurn:
                    yield return StartCoroutine(EnemyTurn());
                    break;
                case BattleState.EndTurn:
                    yield return StartCoroutine(EndTurn());
                    break;
                case BattleState.OutroStage:
                    yield return StartCoroutine(OutroStage());
                    break;
            }
        }
        EndBattle();
    }

    private IEnumerator IntroStage()
    {
        Debug.Log("Let's Battle!");
        tempEnemyValue = Random.Range( 0, 100 ); // 設置敵人的數值
        Debug.Log("The enemy's number is " + tempEnemyValue);
        battleUIManager.DisableSkillButtons();
        yield return new WaitForSeconds(5);
        currentBattleState = BattleState.PlayerTurn;
    }

    private IEnumerator PlayerTurn()
    {
        Debug.Log("Player's Turn");
        if (!battleUIManager.AreSkillButtonsEnabled())
        {
            battleUIManager.EnableSkillButtons();
        }
        while (!PlayerActionCompleted())
        {
            yield return null;
        }
        if (CheckVictory())
        {
            currentBattleState = BattleState.OutroStage;
        }
        else
        {
            tempEnemyValue = Random.Range( 0, 100 ); // 重新設置敵人的數值
            Debug.Log("The enemy's number is " + tempEnemyValue);
            currentBattleState = BattleState.EnemyTurn;
        }
    }

    private IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy's Turn");
        yield return new WaitForSeconds(5);
        if (!CheckVictory())
        {
            currentBattleState = BattleState.OutroStage;
        }
        else
        {
            currentBattleState = BattleState.EndTurn;
        }
    }

    private IEnumerator EndTurn()
    {
        Debug.Log("End Turn");
        currentBattleState = BattleState.PlayerTurn;
        yield return null;
    }

    private IEnumerator OutroStage()
    {
        Debug.Log("Battle Over");
        yield return new WaitForSeconds(5);
        currentBattleState = BattleState.BattleOver;
    }

    private bool PlayerActionCompleted()
    {
        return isPlayerActionCompleted;
    }

    private bool EnemyActionCompleted()
    {
        return isEnemyActionCompleted;
    }

    private bool CheckVictory()
    {
        // 判斷是否達到勝利或結束條件
        bool victory = tempPlayerValue > tempEnemyValue;
        return victory;
    }

    private void EndBattle()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Battle()
    {
        tempPlayerValue = Random.Range( 0, 100 );
        Debug.Log("Your number is " + tempPlayerValue);
        isPlayerActionCompleted = true;
    }
}
