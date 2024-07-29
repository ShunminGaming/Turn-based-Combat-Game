/****************************************************************************************************
單例(Singleton)注意事項
確保單例唯一性：
    DontDestroyOnLoad方法只應在第一個場景中呼叫一次，後續場景中不應再建立新的GameData實例。透過在Awake方法中檢查並銷毀多餘的實例，可以確保單例的唯一性。
數據初始化：
    確保資料在遊戲開始時正確初始化，以避免在存取未初始化變數時出現錯誤。
資料持久化：
    如果你希望在玩家退出遊戲並重新啟動後仍然保留這些數據，可以結合PlayerPrefs或其他持久化儲存方法來保存和載入GameData中的資料。
****************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    public PlayerStats PlayerStats { get; set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

[System.Serializable]
public class PlayerStats
{
    //攻擊力ATK = Attack
    //防禦力DEF = Defense
    //暴擊率CRT = Crit (Critical Rate)
    //速  度SPD = Speed
    //魔法力MAG = Magic (Magic Power)
    //治療力HEL = Heal (Healing Power)

    public int WarriorHP;
    public int WarlockHP;    
    public int HealerHP;
    public int WarriorATK;
    public int WarlockATK;
    public int HealerATK;
    
}
