using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerStatsTxt, characterTxt;
    [SerializeField]
    private TextMeshProUGUI waveStatsTxt, enemiesTxt;
    [SerializeField]
    GameObject SelectCharacterUI;
    public void Awake()
    {
        Game.SetHUDController(this);
    }

    public void CloseCharacterSelectMenu()
    { 
        SelectCharacterUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenCharacterSelectMenu()
    {
        SelectCharacterUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UpdatePlayerStats()
    {
        //Spd: 00, Current Hp: 00, Max Hp: 00 
        playerStatsTxt.text = "Spd: " + Game.GetPlayer().GetMovementSpeed() + " Max Health: " + Game.GetPlayer().GetMaxHp();
        Character character = Game.GetCharacterByRefID(Game.GetPlayer().GetCurrentCharacter());
        characterTxt.text = character.name;
    }

    public void UpdateWaveStats(int waveNo, int enemies)
    {
        waveStatsTxt.text = waveNo.ToString();
        enemiesTxt.text = enemies.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
