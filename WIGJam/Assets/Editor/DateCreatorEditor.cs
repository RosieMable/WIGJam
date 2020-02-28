using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DateCreator))]
public class DateCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DateCreator script = (DateCreator)target;
        if(GUILayout.Button("Save Date"))
        {
            script.SaveIntoJson();
        }
    }
}
