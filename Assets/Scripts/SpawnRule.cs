using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRule : MonoBehaviour
{

    public Unit Monster;
    public float InitTime;
    public float Period;
    public int MaxNum;
    public int HP;
    public int Attack;

    private float timeSinceLevelStart = 0f;
    private float levelStartTime = 0f;

    public UnitManager unitManager;


    int num = 0;
    float timer = 0;

    void Start()
    {
        this.levelStartTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (num >= MaxNum) return;

        if (timeSinceLevelStart > InitTime)
        { // ¿ªÊ¼Ë¢¹Ö
            timer += Time.deltaTime;

            if (timer >= Period)
            {
                timer = 0f;
                Enemy enemy = unitManager.CreateEnemy(this.Monster.gameObject);
                enemy.HP = this.HP;
                num++;
            }


        }


    }
}
