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
    bool isBossCreated = false;
    Boss boss = null;
    public List<SpawnRule> Rules = new List<SpawnRule>();

    private float timeSinceLevelStart = 0f;
    private float levelStartTime = 0f;
    float bossTime = 60f;

    void Start()
    {
        for (int i = 0; i < Rules.Count; i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
        }
    }

    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (timeSinceLevelStart > bossTime)
        {
            if (isBossCreated == false)
            {
                isBossCreated = true;
                this.boss = (Boss)UnitManager.Instance.CreateEnemy(this.bossPrefab.gameObject);
                this.boss.target = Game.Instance.player.transform;
            }
            else if(isBossCreated == true)
            {
                if (this.boss == null)
                {
                    Game.Instance.GameSuccess = true;
                    Game.Instance.GameOver();
                }
            }
        }
    }
}