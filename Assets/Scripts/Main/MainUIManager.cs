using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private Text warriorHPValue;
    [SerializeField] private Text warriorATKValue;
    [SerializeField] private Text warlockHPValue;
    [SerializeField] private Text warlockATKValue;
    [SerializeField] private Text healerHPValue;
    [SerializeField] private Text healerATKValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCharacterStats()
    {
        warriorHPValue.text = GameData.Instance.PlayerStats.WarriorHP.ToString();
        warriorATKValue.text = GameData.Instance.PlayerStats.WarriorATK.ToString();
        warlockHPValue.text = GameData.Instance.PlayerStats.WarlockHP.ToString();
        warlockATKValue.text = GameData.Instance.PlayerStats.WarlockATK.ToString();
        healerHPValue.text = GameData.Instance.PlayerStats.HealerHP.ToString();
        healerATKValue.text = GameData.Instance.PlayerStats.HealerATK.ToString();
    }
}
