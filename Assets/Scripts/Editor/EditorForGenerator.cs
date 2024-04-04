using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generator))]
public class EditorForGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generate"))
        {
            Generator g = target as Generator;
            g.Clear();
            g.Generate();
        }
        if (GUILayout.Button("Clear"))
        {
            Generator g = target as Generator;
            g.Clear();
        }
    }
}
