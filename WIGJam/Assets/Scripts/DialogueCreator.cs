using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DialogueCreator : MonoBehaviour
{
   public List<DialogueBase> dialogues = new List<DialogueBase>();

    public DateBase.Personality personality;
    public void SaveIntoJson()
    {
       string data = JsonUtility.ToJson(this);
        print(data);
        TextAsset dialogueAsset = ConvertStringToTextAsset(data, personality.ToString());
    }


    TextAsset ConvertStringToTextAsset(string text, string textfileName)
    {
        string temporaryTextFileName = textfileName;
        File.WriteAllText(Application.dataPath + "/Resources/DatesDialogues/" + temporaryTextFileName + ".json", text);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        TextAsset textAsset = Resources.Load(temporaryTextFileName) as TextAsset;
        return textAsset;
    }
}

[System.Serializable]
public class DialogueBase
{
    public string id;
    public string text;
    public List<string> responseIds;

    public DialogueBase(string id, string text, List<string> responseIds)
    {
        this.id = id;
        this.text = text;
        this.responseIds = responseIds;
    }

}
