using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StateMachineAbstract), true)]
public class StateMachineInspector : AbstractInspector
{
    StateMachineAbstract _stateMachineAbstract = null;
    private string currentStateTxt;
    private string previousStateTxt;

    protected override void enable()
    {

    }

    protected override void getFields()
    {
    }

    protected override void getProperties()
    {
        _stateMachineAbstract = (StateMachineAbstract)target;
    }

    protected override void mainUI()
    {
        Color defaultColor = GUI.color;

        CustomEditorStyles.SeparatorUI();
        
        EditorGUILayout.LabelField("Initialized States:", CustomEditorStyles.GUIStyle_BoldLabel);

        IReadOnlyList<System.Type> stateTypes = _stateMachineAbstract.GetAllStateTypes();

        if (stateTypes != null)
        {
            int length = stateTypes.Count;
            for (int i = 0; i < length; i++)
            {
                EditorGUILayout.LabelField("- " + stateTypes[i].ToString());
            }
        }
        else
        {
            GUI.color = Color.red;
            EditorGUILayout.LabelField("Statemachine is not initialized yet.");
        }

        GUI.color = defaultColor;

        CustomEditorStyles.SeparatorUI();

        GUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Current State: ");
        
        currentStateTxt = _stateMachineAbstract.CurrentStateType != null ? _stateMachineAbstract.CurrentStateType.ToString() : "NULL";

        if (currentStateTxt == "NULL") GUI.color = Color.red;
        else GUI.color = Color.green;
        EditorGUILayout.LabelField(currentStateTxt, CustomEditorStyles.GUIStyle_BoldLabel);
        GUI.color = defaultColor;

        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        
        EditorGUILayout.LabelField("Previous State: ");

        previousStateTxt = _stateMachineAbstract.PreviousStateType != null ? _stateMachineAbstract.PreviousStateType.ToString() : "NULL";

        if (previousStateTxt == "NULL") GUI.color = Color.red;
        else
            GUI.color = Color.gray;
        EditorGUILayout.LabelField(previousStateTxt, CustomEditorStyles.GUIStyle_BoldLabel);
        GUI.color = defaultColor;
        
        GUILayout.EndHorizontal();
    }
}
