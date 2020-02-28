using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DateCreator : MonoBehaviour
{
    public string name;
    public int age;
    public string bio;
    public DateBase.Personality _personality;




    public DateBase mydate = new DateBase();

    public void SaveIntoJson()
    {
        string filePath = Application.dataPath;
        mydate.name = name;
        mydate.age = age;
        mydate.bio = bio;
        mydate.personality = _personality;

        string date = JsonUtility.ToJson(mydate);
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        TextAsset newDate = ConvertStringToTextAsset(date, mydate.name);

    }


    TextAsset ConvertStringToTextAsset(string text, string textfileName)
    {
        string temporaryTextFileName = textfileName;
        File.WriteAllText(Application.dataPath + "/Resources/DatesCharacters/" + temporaryTextFileName + ".json", text);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        TextAsset textAsset = Resources.Load(temporaryTextFileName) as TextAsset;
        return textAsset;
    }

}



[System.Serializable]
public class DateBase
{
    public string name;
    public int age;
    public string bio;
    public Personality personality;

    public enum Personality
    {
        troll,
        douche,
        niceguy,
        truelove
    }

}
