using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 15f;
    public float tarkingTime = 3f;
    private float timer = 0f;
    public DAMAGE_POWER power = DAMAGE_POWER.Rocket_Hurt;
    public Transform target;
    private Vector3 ret;
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

     void Update()
    {
        timer += Time.deltaTime;
        if (timer < tarkingTime)
        {
            ret = target.transform.position - this.transform.position;
            ret.Normalize();// ¹éÒ»»¯
            this.transform.rotation = Quaternion.FromToRotation(Vector3.right, ret);
        }
        this.transform.position += speed * Time.deltaTime * ret;
        

        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
