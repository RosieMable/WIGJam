using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Ink.Runtime;

public class CardLogic : MonoBehaviour {


    [SerializeField] GameObject LikeButton, DislikeButton;
    [SerializeField] Story DialogueCard;
    [SerializeField] private TextAsset[] doucheStory = null;
    [SerializeField] private TextAsset[] niceGuy = null;
    [SerializeField] private TextAsset[] actualNiceGuy = null;
    [SerializeField] private TextAsset troll = null;
    [SerializeField] TextAsset textChosen = null;
    [SerializeField] string Name, Bio, Gender;
    [SerializeField] int Age;
    [SerializeField] DialogueINK iNK;

    [SerializeField]
    Sprite[] ProfilePics;

    [SerializeField]
    Image CurrentProfilePic;
    Sprite lastChosenPic;

    public enum Personality
    {
        niceGuy,
        actualNiceGuy,
        troll,
        douche,
        nothing
    }

    public Personality personality;


    private void Start()
    {
        PopulateCard();
    }

    public void ChooseProfilePic()
    {
        Sprite newSprite = ProfilePics[Random.Range(0, ProfilePics.Length)];
        lastChosenPic = newSprite;
        CurrentProfilePic.sprite = newSprite;

        if(CurrentProfilePic.sprite == lastChosenPic)
        {
            newSprite = ProfilePics[Random.Range(0, ProfilePics.Length)];
        }

    }

    void ChooseStoryAsset(Personality personality)
    {
        if (personality != Personality.nothing)
        {
            switch (personality)
            {
                case Personality.niceGuy:
                    textChosen = niceGuy[Random.Range(0, niceGuy.Length)];
                    DialogueCard = new Story(textChosen.text);
                    break;
                case Personality.actualNiceGuy:
                    textChosen = actualNiceGuy[Random.Range(0, actualNiceGuy.Length)];
                    DialogueCard = new Story(textChosen.text);
                    break;
                case Personality.troll:
                    textChosen = troll;
                    DialogueCard = new Story(textChosen.text);
                    break;
                case Personality.douche:
                    textChosen = doucheStory[Random.Range(0, doucheStory.Length)];
                    DialogueCard = new Story(textChosen.text);
                    break;
            }
        }
    }

        void PopulateCard()
        {

            ChooseProfilePic();
            ChoosePersonality();

            ChooseStoryAsset(personality);
            Age = Random.Range(20, 38);
        }

    void ChoosePersonality()
    {
        Personality lastPersonalityChosen = Personality.nothing;
        personality = (Personality)Random.Range(0, 3);
        lastPersonalityChosen = personality;



        if (personality == lastPersonalityChosen)
        {
            personality = (Personality)Random.Range(0, 3);
        }

    }

    public void Like()
    {
        iNK.SetStory(textChosen);
        iNK.StartStoryOnPress();
        print("Liked!");
    }

    public void Dislike()
    {
        PopulateCard();
    }

}
