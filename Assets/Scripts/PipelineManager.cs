using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : MonoBehaviour
{
    static public PipelineManager instance;
    public GameObject template;
    Coroutine coroutine = null;

    private void Awake()
    {
        instance = this;
    }
    public void StartRun()
    {
        coroutine = StartCoroutine(CreatePipes());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator CreatePipes()
    {
        while (true)
        {
            CreatePipe();

            yield return new WaitForSeconds(2f);
        }
    }

    private void CreatePipe()
    {
        float y = Random.Range(1.3f, -2.3f);
        GameObject pipe = GameObject.Instantiate(template,new Vector3(9, y, 0),Quaternion.identity ,this.transform);
    }

    public void DestoryAllPipes()
    {
        foreach (Transform pipe in transform)
        {
            Destroy(pipe.gameObject);
        }
    }
}
