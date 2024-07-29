using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // 嘗試加載數值
        GameData.Instance.PlayerStats = SaveSystem.Instance.LoadPlayerStats();

        // 如果沒有儲存檔案，創建新的數值
        if (GameData.Instance.PlayerStats == null)
        {
            GameData.Instance.PlayerStats = new PlayerStats { WarriorHP = 100, WarlockHP = 80, HealerHP = 80, WarriorATK = 20, WarlockATK = 15, HealerATK = 10 };
        }

        // 在這裡可以使用playerStats
        
    }

    public void StartBattle()
    {
        SceneManager.LoadScene("Battle");
    }

    public void EndBattle()
    {
        SceneManager.UnloadSceneAsync("Battle");
    }

    private void OnApplicationQuit()
    {
        // 保存數值
        SaveSystem.Instance.SavePlayerStats(GameData.Instance.PlayerStats);
    }
}
