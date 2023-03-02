using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class CustomEditorStyles
{
    static GUIStyle mGUIStyle_Background;
    static GUIStyle mGUIStyle_Header;
    static GUIStyle mGUIStyle_HandleTitle;
    static GUIStyle mGUIStyle_NormalLabel;
    static GUIStyle mGUIStyle_BoldLabel;
    static GUIStyle mGUIStyle_ButtonSmall;
    static GUIStyle mGUIStyle_ButtonLarge;

    public static GUIStyle GUIStyle_ButtonLarge
    {
        get
        {
            if (mGUIStyle_ButtonLarge == null)
            {
                mGUIStyle_ButtonLarge = new GUIStyle(GUI.skin.button);
                mGUIStyle_ButtonLarge.fontSize = 15;
                mGUIStyle_ButtonLarge.normal.textColor = Color.yellow;
                mGUIStyle_ButtonLarge.fontStyle = FontStyle.BoldAndItalic;
                mGUIStyle_ButtonLarge.alignment = TextAnchor.MiddleCenter;
            }
            return mGUIStyle_ButtonLarge;
        }
    }

    public static GUIStyle GUIStyle_ButtonSmall
    {
        get
        {
            if (mGUIStyle_ButtonSmall == null)
            {
                mGUIStyle_ButtonSmall = new GUIStyle(GUI.skin.button);
                mGUIStyle_ButtonSmall.fontSize = 12;
                mGUIStyle_ButtonSmall.normal.textColor = Color.yellow;
                mGUIStyle_ButtonSmall.fontStyle = FontStyle.BoldAndItalic;
                mGUIStyle_ButtonSmall.alignment = TextAnchor.MiddleCenter;
            }
            return mGUIStyle_ButtonSmall;
        }
    }

    public static GUIStyle GUIStyle_Header
    {
        get
        {
            if (mGUIStyle_Header == null)
            {
                mGUIStyle_Header = new GUIStyle("HeaderLabel");
                mGUIStyle_Header.fontSize = 25;
                mGUIStyle_Header.normal.textColor = Color.yellow;
                mGUIStyle_Header.fontStyle = FontStyle.BoldAndItalic;
                mGUIStyle_Header.alignment = TextAnchor.UpperCenter;
            }
            return mGUIStyle_Header;
        }
    }

    public static GUIStyle GUIStyle_HandleTitle
    {
        get
        {
            if (mGUIStyle_HandleTitle == null)
            {
                mGUIStyle_HandleTitle = new GUIStyle("HandleTitle");
                mGUIStyle_HandleTitle.fontSize = 16;
                mGUIStyle_HandleTitle.normal.textColor = Color.yellow;
                mGUIStyle_HandleTitle.fontStyle = FontStyle.BoldAndItalic;
                mGUIStyle_HandleTitle.alignment = TextAnchor.UpperCenter;
            }
            return mGUIStyle_HandleTitle;
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
                mGUIStyle_BoldLabel.fontStyle = FontStyle.BoldAndItalic;

            }
            return mGUIStyle_BoldLabel;
        }
    }
    public static GUIStyle GUIStyle_NormalLabel
    {
        get
        {
            if (mGUIStyle_NormalLabel == null)
            {
                mGUIStyle_NormalLabel = new GUIStyle("NormalLabel");
                mGUIStyle_NormalLabel.fontSize = 13;
                mGUIStyle_NormalLabel.fontStyle = FontStyle.Normal;
            }
            return mGUIStyle_NormalLabel;
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
        GUILayout.Space(10);
    }

    public static void SeparatorUI(bool i_mini = false)
    {
        if (false == i_mini)
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        else
            EditorGUILayout.LabelField("________________________________________________________________________________________________________________________________________________________________");

    }

    public static void SeparatorUI(Rect i_rect, bool i_mini = false)
    {
        if (false == i_mini)
            EditorGUI.LabelField(i_rect, "", GUI.skin.horizontalSlider);
        else
            EditorGUI.LabelField(i_rect, "________________________________________________________________________________________________________________________________________________________________");

    }

    public static void MiniLabelUI(string i_text)
    {
        EditorGUILayout.LabelField(i_text, EditorStyles.miniLabel);
    }

    public static void MiniLabelUI(Rect i_rect, string i_text)
    {
        EditorGUI.LabelField(i_rect, i_text, EditorStyles.miniLabel);
    }

    public static void TitleUI(GUIContent i_title, bool i_subtitle = false)
    {
        Color col = GUI.color;
        GUI.color = Color.yellow;

        if (false == i_subtitle)
            GUILayout.Space(10);

        SeparatorUI(i_subtitle);

        if (false == i_subtitle)
            GUILayout.Label(i_title, EditorStyles.largeLabel);
        else
            GUILayout.Label(i_title, EditorStyles.label);

        GUI.color = col;

        GUILayout.Space(10);
    }

    public static void TitleUI(string i_title, bool i_subtitle = false)
    {
        TitleUI(new GUIContent(i_title), i_subtitle);
    }

}
