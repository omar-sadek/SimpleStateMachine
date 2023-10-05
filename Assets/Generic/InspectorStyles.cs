using UnityEditor;
using UnityEngine;

public static class InspectorStyles
{
    static GUIStyle mGUIStyle_Background;
    static GUIStyle mGUIStyle_Header;
    static GUIStyle mGUIStyle_BoldLabel;

    public static Color DarkPurpleColor => new Color(0.278f, 0.278f, 0.529f, 1.0f);
    public static Color LightPurpleColor => new Color(0.439f, 0.435f, 0.827f, 1.0f);
    public static Color OffWhiteColor => new Color(0.8196f, 0.8f, 0.7529f, 1.0f);
    public static Color PumpkinColor => new Color(1.0f, 0.475f, 0.247f, 1.0f);
    public static Color WatermelonColor => new Color(1.0f, 0.322f, 0.322f, 1.0f);
    public static Color CelestialGreenColor => new Color(0.2f, 0.85f, 0.698f, 1.0f);

    public static GUIStyle GUIStyle_Header
    {
        get
        {
            if (mGUIStyle_Header == null)
            {
                mGUIStyle_Header = new GUIStyle("HeaderLabel");
                mGUIStyle_Header.fontSize = 25;
                mGUIStyle_Header.normal.textColor = LightPurpleColor;
                mGUIStyle_Header.fontStyle = FontStyle.Bold;
                mGUIStyle_Header.alignment = TextAnchor.UpperCenter;
            }
            return mGUIStyle_Header;
        }
    }

    public static GUIStyle GUIStyle_BoldLabel
    {
        get
        {
            if (mGUIStyle_BoldLabel == null)
            {
                mGUIStyle_BoldLabel = new GUIStyle("BoldLabel");
                mGUIStyle_BoldLabel.fontSize = 13;
                mGUIStyle_BoldLabel.fontStyle = FontStyle.Bold;

            }
            return mGUIStyle_BoldLabel;
        }
    }

    public static GUIStyle GUIStyle_BoldItalicLabel
    {
        get
        {
            if (mGUIStyle_BoldLabel == null)
            {
                mGUIStyle_BoldLabel = new GUIStyle("BoldLabel");
                mGUIStyle_BoldLabel.fontSize = 13;
                mGUIStyle_BoldLabel.fontStyle = FontStyle.BoldAndItalic;

            }
            return mGUIStyle_BoldLabel;
        }
    }
    
    public static GUIStyle GUIStyle_Background
    {
        get
        {
            if (mGUIStyle_Background == null)
            {
                mGUIStyle_Background = new GUIStyle(EditorStyles.textArea);
                mGUIStyle_Background.overflow.left = 50;
                mGUIStyle_Background.overflow.right = 50;
                mGUIStyle_Background.overflow.top = -5;
                mGUIStyle_Background.overflow.bottom = 0;
            }
            return mGUIStyle_Background;
        }
    }

    public static void HeaderUI(string i_title)
    {
        if (GUILayout.Button(i_title, GUIStyle_Header)) { }
        GUILayout.Space(12);
    }

    public static void SeparatorUI(bool i_mini = false)
    {
        if (false == i_mini)
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        else
            EditorGUILayout.LabelField("________________________________________________________________________________________________________________________________________________________________");

    }

    public static void TitleUI(GUIContent i_title, bool i_subtitle = false)
    {
        Color col = GUI.color;
        GUI.color = LightPurpleColor;

        if (false == i_subtitle)
            GUILayout.Space(15);

        SeparatorUI(i_subtitle);

        if (false == i_subtitle)
            GUILayout.Label(i_title, EditorStyles.largeLabel);
        else
            GUILayout.Label(i_title, EditorStyles.label);

        GUI.color = col;

        GUILayout.Space(10);
    }
}
