using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StateEngine
{
    [CustomEditor(typeof(StateMachineAbstract), true)]
    public class StateMachineInspector : AbstractInspector
    {
        StateMachineAbstract _stateMachineAbstract = null;

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

            InspectorStyles.SeparatorUI();

            EditorGUILayout.LabelField("Initialized States:", InspectorStyles.GUIStyle_BoldLabel);

            IReadOnlyList<System.Type> stateTypes = _stateMachineAbstract.GetAllStateTypes();

            if (stateTypes != null)
            {
                int length = stateTypes.Count;
                for (int i = 0; i < length; i++)
                {
                    EditorGUILayout.LabelField("- " + stateTypes[i].Name);
                }
            }
            else
            {
                GUI.color = InspectorStyles.WatermelonColor;
                EditorGUILayout.LabelField("Statemachine is not initialized yet.");
            }

            GUI.color = defaultColor;

            InspectorStyles.SeparatorUI();

            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Current State: ");

            if (_stateMachineAbstract.CurrentStateType == null)
            {
                GUI.color = InspectorStyles.WatermelonColor;
                EditorGUILayout.LabelField("NULL", InspectorStyles.GUIStyle_BoldLabel);
            }
            else
            {
                GUI.color = InspectorStyles.CelestialGreenColor;
                EditorGUILayout.LabelField(
                    _stateMachineAbstract.CurrentStateType.Name, InspectorStyles.GUIStyle_BoldLabel);
            }

            GUI.color = defaultColor;

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Previous State: ");

            if (_stateMachineAbstract.PreviousStateType == null)
            {
                GUI.color = InspectorStyles.WatermelonColor;
                EditorGUILayout.LabelField("NULL", InspectorStyles.GUIStyle_BoldLabel);
            }
            else
            {
                GUI.color = InspectorStyles.OffWhiteColor;
                EditorGUILayout.LabelField(_stateMachineAbstract.PreviousStateType.Name,
                    InspectorStyles.GUIStyle_BoldLabel);
            }
            
            GUI.color = defaultColor;

            GUILayout.EndHorizontal();
        }
    }
}