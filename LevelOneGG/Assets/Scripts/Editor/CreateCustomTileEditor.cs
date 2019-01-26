using UnityEngine;
using UnityEditor;
using System.Collections;

class CreateCustomTileEditor : EditorWindow
{
    [MenuItem("Window/CreateCustomTileEditor")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CreateCustomTileEditor));
    }

    void OnGUI()
    {
        //EditorGUILayout
    }
}
