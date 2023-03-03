using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StateMachine), true)]
public class StateMachineInspector : AbstractInspector
{
    StateMachine stateMachine = null;
    protected override void enable()
    {

    }

    protected override void getFields()
    {
    }

    protected override void getProperties()
    {
        stateMachine = (StateMachine)target;
    }

    protected override void mainUI()
    {
        CustomEditorStyles.SeparatorUI();

        GUILayout.BeginHorizontal();

        Color defaultColor = GUI.color;
        GUI.color = Color.yellow;
        EditorGUILayout.LabelField("Current State: ");
        GUI.color = defaultColor;

        string currentStateTxt = stateMachine != null ? stateMachine.ToString() : "NULL";
        if (currentStateTxt == "NULL") GUI.color = Color.red;
        EditorGUILayout.LabelField(currentStateTxt, CustomEditorStyles.GUIStyle_BoldLabel);
        GUI.color = defaultColor;

        GUILayout.EndHorizontal();
    }
}
