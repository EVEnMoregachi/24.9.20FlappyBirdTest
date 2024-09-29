using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRule : MonoBehaviour
{

    public Unit Monster;//怪物的模板
    public float InitTime;//开始刷怪时间
    public float Period;//刷怪间隔
    public int MaxNum;//刷怪的数量
    public int HP;//怪物血量

    private float timeSinceLevelStart = 0f;
    private float levelStartTime = 0f;

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
        { // 开始刷怪
            timer += Time.deltaTime;

            if (timer >= Period)
            {
                timer = 0f;
                Enemy enemy = UnitManager.Instance.CreateEnemy(this.Monster.gameObject);
                enemy.HP = this.HP;
                num++;
            }
        }
    }
}
