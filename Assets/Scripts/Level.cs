using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int LevelID;
    public string Name;

    public Boss bossPrefab;

    public List<SpawnRule> Rules = new List<SpawnRule>();

    public UnitManager unitManager;

    private float timeSinceLevelStart = 0f;
    private float levelStartTime = 0f;
    float bossTime = 1f;
    float timer = 0f;

    public Player currentplayer;

    Boss boss = null;
    void Start()
    {
        for (int i = 0; i < Rules.Count; i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
            rule.unitManager = this.unitManager;
        }
    }

    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (timeSinceLevelStart > bossTime)
        {
            if (boss == null)
            {
                boss = (Boss)unitManager.CreateEnemy(this.bossPrefab.gameObject);
                boss.target = currentplayer.transform;
            }
        }
    }
}
