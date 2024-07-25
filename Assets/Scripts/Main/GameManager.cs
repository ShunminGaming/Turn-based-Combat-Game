using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private enum GameState { MainGame, Battle, GameOver }
    private GameState currentState;

    void Start()
    {
        currentState = GameState.MainGame;
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.MainGame:
                // 主遊戲邏輯
                if (Input.GetKeyDown(KeyCode.B)) // 假設按下B鍵進入戰鬥
                {
                    StartBattle();
                }
                break;
            case GameState.Battle:
                // 戰鬥邏輯在BattleScene中管理
                break;
            case GameState.GameOver:
                // 遊戲結束邏輯
                break;
        }
    }

    public void StartBattle()
    {
        if (currentState == GameState.MainGame)
        {
            currentState = GameState.Battle;
            SceneManager.LoadScene("Battle");
        }
    }

    public void EndBattle()
    {
        currentState = GameState.MainGame;
        SceneManager.UnloadSceneAsync("Battle");
    }
}
