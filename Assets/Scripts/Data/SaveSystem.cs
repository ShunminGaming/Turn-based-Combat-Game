using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    private string filePath;

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
        
        filePath = Path.Combine(Application.persistentDataPath, "playerStats.json");
    }

    public void SavePlayerStats(PlayerStats stats)
    {
        string json = JsonUtility.ToJson(stats);
        File.WriteAllText(filePath, json);
        Debug.Log("Player stats saved to " + filePath);
    }

    public PlayerStats LoadPlayerStats()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerStats stats = JsonUtility.FromJson<PlayerStats>(json);
            Debug.Log("Player stats loaded from " + filePath);
            return stats;
        }
        else
        {
            Debug.LogWarning("No save file found at " + filePath);
            return null;
        }
    }
}
