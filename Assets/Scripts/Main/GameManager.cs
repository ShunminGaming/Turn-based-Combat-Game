using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        GameData.Instance.WarriorAttack = 1;
        GameData.Instance.WarlockAttack = 1;
        GameData.Instance.HealerAttack = 1;
    }

    void Update()
    {
        
    }

    public void StartBattle()
    {
        SceneManager.LoadScene("Battle");
    }

    public void EndBattle()
    {
        SceneManager.UnloadSceneAsync("Battle");
    }
}
