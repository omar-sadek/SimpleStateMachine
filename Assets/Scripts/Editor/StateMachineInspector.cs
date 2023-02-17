using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StateMachine))]
public class StateMachineInspector : Editor
{
    StateMachine currentState;

    public void OnEnable()
    {
        currentState = target as StateMachine;
    }
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField(currentState.name);
    }

}
