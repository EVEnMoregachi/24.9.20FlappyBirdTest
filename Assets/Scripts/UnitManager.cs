using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    Coroutine coroutine = null;

    public void StartRun()
    {
        coroutine = StartCoroutine(CreateEnemys());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    float timer1 = 0;
    float timer2 = 0;
    float timer3 = 0;
    IEnumerator CreateEnemys()
    {
        while (true)
        {
            if (timer1 >= 1)
            {
                CreateEnemy(enemy1);
                timer1 = 0;
            }
            if (timer2 >= 2)
            {
                CreateEnemy(enemy2);
                timer2 = 0;
            }
            if (timer3 >= 4)
            {
                CreateEnemy(enemy3);
                timer3 = 0;
            }
            timer1++;
            timer2++;
            timer3++;
            yield return new WaitForSeconds(1f);
        }
    }

    private void CreateEnemy(GameObject enemytype)
    {
        float y = Random.Range(3f, -3f);
        GameObject enemy = GameObject.Instantiate(enemytype, new Vector3(this.transform.position.x, this.transform.position.y + y, 0), Quaternion.identity, this.transform);
    }

    public void DestoryAllEnemys()
    {
        foreach (Transform i in transform)
        {
            Destroy(i.gameObject);
        }
    }
}
