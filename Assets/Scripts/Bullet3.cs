using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet3 : Bul
{
    public Vector3 ret;
    public override void OnStart()
    {
        this.transform.rotation = Quaternion.FromToRotation(Vector3.left, ret);
    }
    public override void OnUpdate()
    {
        this.transform.position += ret * speed * Time.deltaTime;

        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
