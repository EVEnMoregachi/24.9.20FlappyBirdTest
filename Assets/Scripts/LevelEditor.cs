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
            level.Rules = new List<SpawnRule>(); // 确保规则列表不为空
        }

        scrollPos = GUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginVertical();

        for (int i = 0; i < level.Rules.Count; i++)
        {
            if (level.Rules[i] != null) // 检查每个 SpawnRule 是否为 null
            {
                EditorGUILayout.ObjectField(level.Rules[i].Monster, typeof(Unit), true);
            }
            else
            {
                GUILayout.Label("Rule is null"); // 处理 null 的情况
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
