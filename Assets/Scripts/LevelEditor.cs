using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    Level level;


    Vector2 scrollPos;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        level = target as Level;
        OnRulesGUI(level);
    }

    void OnRulesGUI(Level level)
    {
        GUILayout.Label("Rules:");

        if (level.Rules == null)
        {
            level.Rules = new List<SpawnRule>(); // ȷ�������б�Ϊ��
        }

        scrollPos = GUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginVertical();

        for (int i = 0; i < level.Rules.Count; i++)
        {
            if (level.Rules[i] != null) // ���ÿ�� SpawnRule �Ƿ�Ϊ null
            {
                EditorGUILayout.ObjectField(level.Rules[i].Monster, typeof(Unit), true);
            }
            else
            {
                GUILayout.Label("Rule is null"); // ���� null �����
            }
        }

        GUILayout.EndVertical();
        GUILayout.EndScrollView();

        if (GUILayout.Button("Add Rule"))
        {
            level.Rules.Add(new SpawnRule());
        }
    }
}
