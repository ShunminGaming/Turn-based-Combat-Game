using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
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
