using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{

    [Header("Wave Txt")]
    [SerializeField] private TextMeshProUGUI waveStatsTxt, enemiesTxt;
    [Header("Select Character UI")]
    [SerializeField] GameObject SelectCharacterUI;
    [Header("Character Sprite")]
    [SerializeField] Sprite[] CharacterSprites;
    [SerializeField] SpriteRenderer HPSprite;
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

    public void ChangeCharacterSprite(string characterID)
    {
        //get the character id
        Character c = Game.GetCharacterByRefID(characterID);

        if (c.name == "Red Riding Hood")
        {
            HPSprite.sprite = CharacterSprites[0];
        }
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
