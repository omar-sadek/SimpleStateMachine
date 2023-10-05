using UnityEditor;
using UnityEngine;

public abstract class AbstractInspector : Editor
{
    protected string title = null;

    #region UNITY & CORE

    public void OnEnable()
    {
        title = target.GetType().Name;

        enable();
        getFields();
        getProperties();
    }
    private void OnDisable()
    {
        // trySetRepaintCallback(null);

        disable();
    }
    public override void OnInspectorGUI()
    {
        GUI.backgroundColor = InspectorStyles.DarkPurpleColor;
        GUILayout.BeginVertical(InspectorStyles.GUIStyle_Background, GUILayout.Height(1));
        GUI.backgroundColor = Color.white;

        if (true == EditorApplication.isCompiling)
        {
            InspectorStyles.HeaderUI("Compiling...");
            return;
        }

        getFields();

        InspectorStyles.HeaderUI(title);

        base.OnInspectorGUI();

        mainUI();

        GUILayout.Space(10);

        GUILayout.EndVertical();

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }
    #endregion

    protected virtual void disable()
    {

    }

    #region ABSTRACT API
    protected abstract void enable();

    protected abstract void getFields();

    protected abstract void getProperties();

    protected abstract void mainUI();

    #endregion
}
