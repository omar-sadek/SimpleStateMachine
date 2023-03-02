using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterStateMachine))]
[CanEditMultipleObjects]
public class StateMachineInspector : AbstractInspector
{
    SerializedProperty p_currentState = null;

    protected override void enable()
    {
    }

    protected override void getFields()
    {
    }

    protected override void getProperties()
    {
        p_currentState = serializedObject.FindProperty("currentState");
    }

    protected override void mainUI()
    {
        CustomEditorStyles.SeparatorUI();

        GUILayout.BeginHorizontal();

        Color defaultColor = GUI.color;
        GUI.color = Color.yellow;
        EditorGUILayout.LabelField("Current State: ");
        GUI.color = defaultColor;

        string currentStateTxt = p_currentState != null ? p_currentState.ToString() : "NONE";
        EditorGUILayout.LabelField(currentStateTxt, CustomEditorStyles.GUIStyle_BoldLabel);

        GUILayout.EndHorizontal();
    }
}
