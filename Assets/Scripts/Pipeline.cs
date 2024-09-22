using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public int PipeSpeed = 4;
    void Start()
    {
        Destroy(this.gameObject, 12f);
    }

    void Update()
    {
        this.transform.position += new Vector3(-1, 0) * Time.deltaTime * PipeSpeed;
    }
}
