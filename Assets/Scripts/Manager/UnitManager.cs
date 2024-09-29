using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class UnitManager : MonoSingleton<UnitManager>
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    Coroutine coroutine = null;

    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    public Enemy CreateEnemy(GameObject enemytype)
    {
        if (enemytype == null)
            return null;

        float y = Random.Range(3f, -3f);
        GameObject go = GameObject.Instantiate(enemytype, new Vector3(this.transform.position.x, this.transform.position.y + y, 0), Quaternion.identity, this.transform);
        Enemy enemy = go.GetComponent<Enemy>();
        return enemy;
    }

    public void DestoryAllEnemys()
    {
        foreach (Transform i in transform)
        {
            Destroy(i.gameObject);
        }
    }
}
