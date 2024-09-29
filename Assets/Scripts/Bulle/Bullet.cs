using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : Bul
{
    public override void OnUpdate()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
