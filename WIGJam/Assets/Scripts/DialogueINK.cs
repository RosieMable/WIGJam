﻿using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;
using System.Collections.Generic;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class DialogueINK : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story story;

    [SerializeField]
    private TextAsset TrollEXC;

    [SerializeField]
    private GameObject canvas = null;

    [SerializeField]
    GameManager manager;

    // UI Prefabs
    [SerializeField]
    private GameObject textPrefab = null;
    [SerializeField]
    private Button buttonPrefab = null;

    [SerializeField]
    private Transform P1, P2, CenterPoint;

    [SerializeField]
    Sprite Left, Right;

    [SerializeField]
    List<GameObject> ToRefresh;

    public CardLogic.Personality currentPersonality;

    public CardLogic cardDate;

    public GameObject leftButton, rightButton;


    //   void Awake () {
    //	// Remove the default message
    //	RemoveChildren();
    //	StartStory();
    //}
    public void StartStoryOnPress()
    {
        StartStory();
    }
    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        manager.ToChatService();
        story = new Story(inkJSONAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }

    public void BlockUser()
    {
        RemoveChildren();
        manager.blockCount += 1;
        manager.ToFindDate();
        cardDate.PopulateCard();
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    void RefreshView()
    {
        // Remove all the UI on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
            CenterPoint.gameObject.SetActive(true);
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];


                if (story.currentChoices.Count > 1)
                {

                    if (i == 0)
                    {
                        if (inkJSONAsset == TrollEXC)
                        {
                            P1.gameObject.SetActive(false);
                        }
                        Button button = CreateChoiceView(leftButton, choice.text.Trim());
                        button.transform.position = P1.position;
                        button.transform.SetParent(P1);
                        P1.gameObject.SetActive(true);

                        // Tell the button what to do when we press it
                        button.onClick.AddListener(delegate {
                            OnClickChoiceButton(choice);
                        });
                    }
                    else if (i == 1)
                    {
                        Button button = CreateChoiceView(rightButton, choice.text.Trim());
                        button.transform.position = P2.position;
                        button.transform.SetParent(P2);
                        P2.gameObject.SetActive(true);

                        // Tell the button what to do when we press it
                        button.onClick.AddListener(delegate {
                            OnClickChoiceButton(choice);
                        });
                    }

                }
                else
                {
                    if (i == 0)
                    {
                        if (inkJSONAsset == TrollEXC)
                        {
                            P1.gameObject.SetActive(false);
                        }
                        Button button = CreateChoiceView(leftButton, choice.text.Trim());
                        button.transform.position = P1.position;
                        button.transform.SetParent(P1);

                        P2.gameObject.SetActive(false);

                        // Tell the button what to do when we press it
                        button.onClick.AddListener(delegate {
                            OnClickChoiceButton(choice);
                        });
                    }
                   
                }

            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            P1.gameObject.SetActive(false);
            P2.gameObject.SetActive(false);
            CenterPoint.gameObject.SetActive(false);

            //once it is done, then play ending
            manager.ToFindDate();
            cardDate.PopulateCard();
            AddToCount(currentPersonality);


            //Button choice = CreateChoiceView("End of story.\nRestart?");
            //choice.onClick.AddListener(delegate {
            //    StartStory();
            //});
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    // Creates a textbox showing the the line of text
    void CreateContentView(string text)
    {
        GameObject newMessage = Instantiate(textPrefab);
        Text storyText = newMessage.GetComponentInChildren<Text>();
        storyText.text = text;
        newMessage.transform.SetParent(canvas.transform, false);
        newMessage.transform.position = CenterPoint.position;
        newMessage.transform.SetParent(CenterPoint);
        ToRefresh.Add(newMessage.gameObject);
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(GameObject buttonPrefab, string text)
    {
        // Creates the button from a prefab
         GameObject newChoice = Instantiate(buttonPrefab);
        Button choice = newChoice.GetComponent<Button>();
        newChoice.transform.SetParent(canvas.transform, false);

        // Gets the text from the button prefab
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;
        ToRefresh.Add(choice.gameObject);

        return choice;
    }

    // Destroys all the children of this gameobject (all the UI)
    void RemoveChildren()
    {
        if(ToRefresh.Count > 0)
        {
            int childCount = ToRefresh.Count;
            for (int i = childCount - 1; i >= 0; --i)
            {
                GameObject.Destroy(ToRefresh[i]);
            }
        }
        
    }

    public void SetStoryAndGetPersonality(TextAsset inkStory, CardLogic.Personality personality)
    {
        inkJSONAsset = null;
        inkJSONAsset = inkStory;

        currentPersonality = personality;
    }

    void AddToCount(CardLogic.Personality personality)
    {
        switch (personality)
        {
            case CardLogic.Personality.niceGuy:
                manager.blockCount += 1;
                break;
            case CardLogic.Personality.actualNiceGuy:
                manager.niceGuy += 1;
                break;
            case CardLogic.Personality.oneLiners:
                manager.blockCount += 1;
                break;
            case CardLogic.Personality.troll:
                manager.blockCount += 1;
                break;
            case CardLogic.Personality.douche:
                manager.blockCount += 1;
                break;
        }

    }
   public void JustNo()
    {
        manager.blockCount += 1;
    }
}