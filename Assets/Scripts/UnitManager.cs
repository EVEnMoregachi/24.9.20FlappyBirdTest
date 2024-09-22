using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject template;
    Coroutine coroutine = null;

    public void StartRun()
    {
        coroutine = StartCoroutine(CreateEnemys());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator CreateEnemys()
    {
        while (true)
        {
            CreateEnemy();
            yield return new WaitForSeconds(2f);
        }
    }

    private void CreateEnemy()
    {
        float y = Random.Range(3f, -3f);
        GameObject enemy = GameObject.Instantiate(template, new Vector3(this.transform.position.x, this.transform.position.y + y, 0), Quaternion.identity, this.transform);
    }

    public void DestoryAllEnemys()
    {
        foreach (Transform i in transform)
        {
            Destroy(i.gameObject);
        }
    }
}
