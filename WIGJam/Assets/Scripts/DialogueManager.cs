using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;

public class DialogueManager : MonoBehaviour
{

    public TextAsset NpcDialogue;
    public TextAsset PlayerDialogue;

    public bool clearEventsOnStart = true; // For testing

    public string startingIndex;
    public int talkingDistance = 4;
    public float pauseBetweenLines = 0.2f;

    public List<string> dialogueIDs;

    public List<string> playerDialogueIDs;

    private JSONNode dialogueCatalog;
    private JSONNode playerDialogueCatalog;
    private bool isConversing = false;

    // Using these for if we ever change json schema
    private const string TEXT_KEY = "text";
    private const string AUDIO_KEY = "voice";
    private const string NEXT_KEY = "nextLine";
    private const string ALTERNATE_KEY = "alternateLine";
    private const string RESPONSE_KEY = "responseIds";
    private const string OPTION_KEY = "option";
    private const string CONDITION_KEY = "condition";
    private const string APPLY_CONDITION_KEY = "applyCondition";

    private GameObject player;
    private GameObject clickToTalk;
    [SerializeField]
    private UIDialogue uiDialogue;

    private Dictionary<string, AudioClip> dialogueDict;
    private Dictionary<string, AudioClip> playerDialogueDict;

    public void initiateDefaultConversation()
    {
        if (!isConversing)
        {
            isConversing = true;
            say(startingIndex, false);
        }
    }

    public void initiateSpecificConversation(string startingId)
    {
        if (!isConversing)
        {
            isConversing = true;
            say(startingId, false);
            print(dialogueCatalog);
        }
    }

    void endDialogue()
    {
        isConversing = false;
        uiDialogue.hideSubtitle();
    }

    private JSONNode getProperDialogueSet(bool isPlayer)
    {
        return isPlayer ? playerDialogueCatalog : dialogueCatalog;
    }

    public void appendText(TextAsset file, string eventName)
    {
        File.AppendAllText(UnityEditor.AssetDatabase.GetAssetPath(file), "," + eventName);
        UnityEditor.EditorUtility.SetDirty(file);
        UnityEditor.AssetDatabase.Refresh();
    }

    public void say(string index, bool isPlayer)
    {

        JSONNode dialogueSet = getProperDialogueSet(isPlayer);

        print(dialogueSet);

        JSONNode conditon = dialogueSet[index][CONDITION_KEY];

        if (!conditon.Equals(null))
        {
            Debug.Log("A");

            Debug.Log(conditon);
        }

        string subtitle = dialogueSet[index][TEXT_KEY];


        uiDialogue.displaySubtitle(subtitle);
        print(subtitle);


        string nextLine = dialogueSet[index][NEXT_KEY];

        string[] ids = toStringArray(dialogueSet[index][RESPONSE_KEY].AsArray);

        if (nextLine != null && nextLine.Length > 0)
        {

           say(nextLine, isPlayer);

        }
        else if (ids.Length > 1)
        {

            // Player will only ever get to make choices
            // so we know this must be a player-controlled choice
            uiDialogue.showOptions(getOptionsText(index, ids), ids, this);

        }
        else if (ids.Length == 1)
        {
            // This could be player or an NPC so just flip isPlayer and speak
            say(ids[0], !isPlayer);

        }
        else if (ids.Length == 0)
        {
            endDialogue();
        }
    }

    private string[] getOptionsText(string index, string[] ids)
    {
        string[] options = new string[ids.Length];

        for (int i = 0; i < ids.Length; i++)
        {
            options[i] = playerDialogueCatalog[ids[i]][OPTION_KEY];
        }

        return options;
    }

    private string[] toStringArray(JSONArray arr)
    {
        string[] strArr = new string[arr.Count];

        for (int i = 0; i < arr.Count; i++)
        {
            strArr[i] = arr[i];
        }

        return strArr;
    }


    public void parseDialogue()
    {
        dialogueCatalog = JSON.Parse(NpcDialogue.text);
        playerDialogueCatalog = JSON.Parse(PlayerDialogue.text);
    }

    public void displayTalkButton()
    {
        clickToTalk.SetActive(true);
    }

    public void hideTalkButton()
    {
        clickToTalk.SetActive(false);
    }

    void Start()
    {
        parseDialogue();
    }

}
