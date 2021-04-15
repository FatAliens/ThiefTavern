using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCharacter : MonoBehaviour
{
    public Sprite CharacterSkin;
    public int Fraction;
    public QuestsInfo CharacterQuest;
    void Start()
    {
        Fraction = Random.Range(0, 4);
        CharacterSkin = GetComponent<CharacterInfo>().GenerateCharacterSprite(Fraction);
        CharacterQuest = GetComponent<CharacterInfo>().GenerateCharacterQuest(Fraction);
        GetComponent<SpriteRenderer>().sprite = CharacterSkin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
