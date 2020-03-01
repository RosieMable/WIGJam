using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Ink.Runtime;
using System;

public class CardLogic : MonoBehaviour {

    [SerializeField] Story DialogueCard;
    [SerializeField] private TextAsset[] doucheStory = null;
    [SerializeField] private TextAsset doucheBio = null;
    [SerializeField] private TextAsset[] niceGuy = null;
    [SerializeField] private TextAsset niceGuyBio = null;
    [SerializeField] private TextAsset[] actualNiceGuy = null;
    [SerializeField] private TextAsset actualNiceGuyBio = null;
    [SerializeField] private TextAsset[] troll = null;
    [SerializeField] private TextAsset oneLiners = null;
    [SerializeField] private TextAsset trollBio = null;
    [SerializeField] TextAsset textChosen = null;

    AudioSource source;

    [SerializeField] string Name, Bio;
    [SerializeField] int Age;

    [SerializeField] DialogueINK iNK;

    public Story NameStory;
    public TextAsset textAssetNames;

    public Story BioStory;
    public TextAsset ChosenBio;


    [SerializeField]
    Sprite[] ProfilePics;

    [SerializeField]
    Image CurrentProfilePic;
    Sprite lastChosenPic;

    public Text NameAndAgeUI;
    public Text BioTextUI;

    public int luck = 0;

    public enum Personality
    {
        niceGuy,
        oneLiners,
        troll,
        douche,
        actualNiceGuy,
        nothing
    }

    public Personality personality;


    private void Start()
    {
        PopulateCard();
        source = GetComponent<AudioSource>();
    }

    public void ChooseProfilePic()
    {
        Sprite newSprite = ProfilePics[UnityEngine.Random.Range(0, ProfilePics.Length)];
        lastChosenPic = newSprite;
        CurrentProfilePic.sprite = newSprite;

        if(CurrentProfilePic.sprite == lastChosenPic)
        {
            newSprite = ProfilePics[UnityEngine.Random.Range(0, ProfilePics.Length)];
        }

    }

    void ChooseBio(Personality personality)
    {
        ChosenBio = null;

        if (personality != Personality.nothing)
        {
            switch (personality)
            {
                case Personality.niceGuy:
                    ChosenBio = niceGuyBio;
                    BioStory = new Story(ChosenBio.text);
                    BioStory.Continue();
                    BioTextUI.text = BioStory.currentText;
                    break;
                case Personality.actualNiceGuy:
                    ChosenBio = actualNiceGuyBio;
                    BioStory = new Story(ChosenBio.text);
                    BioStory.Continue();
                    BioTextUI.text = BioStory.currentText;
                    break;
                case Personality.troll:
                    ChosenBio = trollBio;
                    BioStory = new Story(ChosenBio.text);
                    BioStory.Continue();
                    BioTextUI.text = BioStory.currentText;
                    break;
                case Personality.douche:
                    ChosenBio = doucheBio;
                    BioStory = new Story(ChosenBio.text);
                    BioStory.Continue();
                    BioTextUI.text = BioStory.currentText;
                    break;
                case Personality.oneLiners:
                    ChosenBio = trollBio;
                    BioStory = new Story(ChosenBio.text);
                    BioStory.Continue();
                    BioTextUI.text = BioStory.currentText;
                    break;

            }
        }

        BioTextUI.text = BioStory.currentText;
    }

    void ChooseStoryAsset(Personality personality)
    {
        if (personality != Personality.nothing)
        {
            switch (personality)
            {
                case Personality.niceGuy:
                    textChosen = niceGuy[UnityEngine.Random.Range(0, niceGuy.Length)];
                    BioStory = new Story(textChosen.text);
                    break;
                case Personality.actualNiceGuy:
                    textChosen = actualNiceGuy[UnityEngine.Random.Range(0, actualNiceGuy.Length)];
                    DialogueCard = new Story(textChosen.text);
                    break;
                case Personality.troll:
                    textChosen = troll[UnityEngine.Random.Range(0, troll.Length)];
                    DialogueCard = new Story(textChosen.text);
                    break;
                case Personality.douche:
                    textChosen = doucheStory[UnityEngine.Random.Range(0, doucheStory.Length)];
                    DialogueCard = new Story(textChosen.text);
                    break;
                case Personality.oneLiners:
                    textChosen = oneLiners;
                    DialogueCard = new Story(textChosen.text);
                    break;
            }
        }
    }

   public void PopulateCard()
        {
            luck = 0;

            luck = UnityEngine.Random.Range(0, 100);

          ChooseProfilePic();
         ChoosePersonality();
        ChooseNameAndAge();
        ChooseStoryAsset(personality);
        ChooseBio(personality);

    }

    void ChoosePersonality()
    {
        if (luck > 0  && luck <= 30) //0 - 30
        {
            personality = Personality.oneLiners;
        }
        else if (luck > 30 && luck <= 50) //31 - 50
        {
            personality = Personality.troll;
        }
        else if (luck > 50 && luck <= 70) // 51 - 70
        {
            personality = Personality.douche;

        }
        else if (luck > 70 && luck <= 95)// 71 - 95
        {
            personality = Personality.niceGuy;
        }
        else if (luck > 95) //96 - 100
        {
            personality = Personality.actualNiceGuy;
        }

        print("Luck is: " + luck.ToString()  + " "+ "Personality is: " + personality);

    }

    void ChooseNameAndAge()
    {
        NameStory = new Story(textAssetNames.text); 
        NameStory.Continue();
        Age = UnityEngine.Random.Range(20, 38);
        Name = NameStory.currentText;
        NameAndAgeUI.text = Name + Age.ToString();
    }

    public void Like()
    {
        source.Play();
        iNK.SetStoryAndGetPersonality(textChosen, personality);
        iNK.StartStoryOnPress();
        print("Liked!");
    }

    public void Dislike()
    {
        source.Play();
        PopulateCard();

    }

}
