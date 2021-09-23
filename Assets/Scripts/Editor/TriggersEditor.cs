using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TriggerScript))]
public class TriggersEditor : Editor
{

    SerializedProperty displayMode;

    private void OnEnable()
    {

        displayMode = serializedObject.FindProperty("triggerMode");

    }


    public override void OnInspectorGUI()
    {
       

        TriggerScript script = (TriggerScript)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(displayMode);

        if (script.triggerMode == TriggerScript.TriggerMode.swimTrigger)
        {

            

        }



        serializedObject.ApplyModifiedProperties();

    }

}
