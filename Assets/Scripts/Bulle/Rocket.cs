using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bul
{
    public float tarkingTime = 3f;
    private float timer = 0f;
    public Transform target;
    private Vector3 ret;
    public override void OnStart()
    {
        Destroy(this.gameObject, 10f);
    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer < tarkingTime)
        {
            ret = target.transform.position - this.transform.position;
            ret.Normalize();// ¹éÒ»»¯
            this.transform.rotation = Quaternion.FromToRotation(Vector3.right, ret);
        }
        this.transform.position += speed * Time.deltaTime * ret;
    }
}
