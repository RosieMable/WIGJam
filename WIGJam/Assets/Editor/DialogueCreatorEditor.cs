using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DialogueCreator))]
public class DialogueCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueCreator script = (DialogueCreator)target;
        if (GUILayout.Button("Save Dialogue"))
        {
            script.SaveIntoJson();
        }
    }
}
