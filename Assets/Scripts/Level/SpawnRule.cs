using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRule : MonoBehaviour
{

    public Unit Monster;//�����ģ��
    public float InitTime;//��ʼˢ��ʱ��
    public float Period;//ˢ�ּ��
    public int MaxNum;//ˢ�ֵ�����
    public int HP;//����Ѫ��

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
        { // ��ʼˢ��
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
