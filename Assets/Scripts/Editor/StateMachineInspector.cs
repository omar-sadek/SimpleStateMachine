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

        //TODO: Show StateEngine Information on the inspector
        EditorGUILayout.LabelField(currentState.name);
    }

}
