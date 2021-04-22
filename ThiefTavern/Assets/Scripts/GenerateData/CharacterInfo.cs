using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public int Fraction;

    [SerializeField] private Sprite CharacterSkin;

    [SerializeField] SkinsContainer SkinContainer;

    [SerializeField] private int SpriteNumber;
    [SerializeField] private int FractionSkinsNumber;

    [SerializeField] private QuestsContainer QuestContainer;
    [SerializeField] private QuestsInfo Quest;

    [SerializeField] private int QuestChance;
    [SerializeField] private int QuestNumber;
    [SerializeField] private int FractionQuestNumber;

    private void Start()
    {
        Fraction = Random.Range(0, 4);
    }
    public QuestsInfo GenerateCharacterQuest(int Fraction)
    {   
        QuestChance = Random.Range(0, 100);
        if (QuestChance >= 0 && QuestChance <= 20)
        {
            FractionQuestNumber = QuestContainer.FractionQuests[Fraction].Quests.Length;
            QuestNumber = Random.Range(0, FractionQuestNumber);
            Quest = QuestContainer.FractionQuests[Fraction].Quests[QuestNumber];
        }
        return Quest;
    }
    public Sprite GenerateCharacterSprite(int Fraction)
    {
        Debug.Log(Fraction);
        FractionSkinsNumber = SkinContainer.Fractions[Fraction].Skins.Length;
        SpriteNumber = Random.Range(0, FractionSkinsNumber);
        CharacterSkin = SkinContainer.Fractions[Fraction].Skins[SpriteNumber];
        return CharacterSkin;
    }

    
}
