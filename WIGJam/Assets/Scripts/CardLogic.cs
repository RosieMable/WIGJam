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
    [SerializeField] private TextAsset troll = null;
    [SerializeField] private TextAsset trollBio = null;
    [SerializeField] TextAsset textChosen = null;

    AudioSource source;

    [SerializeField] string Name, Bio, Gender;
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
                    textChosen = troll;
                    DialogueCard = new Story(textChosen.text);
                    break;
                case Personality.douche:
                    textChosen = doucheStory[UnityEngine.Random.Range(0, doucheStory.Length)];
                    DialogueCard = new Story(textChosen.text);
                    break;
            }
        }
    }

        void PopulateCard()
        {

            ChooseProfilePic();
            ChoosePersonality();
            ChooseNameAndAge();
            ChooseStoryAsset(personality);
            ChooseBio(personality);

            if(ChosenBio == null)
            {
            ChooseBio(personality);
            }

        }

    void ChoosePersonality()
    {
        Personality lastPersonalityChosen = Personality.nothing;
        personality = (Personality)UnityEngine.Random.Range(0, 4);
        lastPersonalityChosen = personality;



        if (personality == lastPersonalityChosen)
        {
            personality = (Personality)UnityEngine.Random.Range(0, 4);
        }

    }

    void ChooseNameAndAge()
    {
        NameStory = new Story(textAssetNames.text); 
        NameStory.Continue();
        Age = UnityEngine.Random.Range(20, 38);
        Name = NameStory.currentText;
        print(NameStory.currentText);

        NameAndAgeUI.text = Name + Age.ToString();
    }

    public void Like()
    {
        source.Play();
        iNK.SetStory(textChosen);
        iNK.StartStoryOnPress();
        print("Liked!");
    }

    public void Dislike()
    {
        source.Play();
        PopulateCard();

    }

}
