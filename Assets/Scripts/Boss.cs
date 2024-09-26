using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject missileTemplate;
    public GameObject bullet3;
    public GameObject gun2;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform target;
    private Vector3 ret2;
    private float fireTime2 = 0f;
    public float FireRate2 = 1f;
    private float fireTime3 = 0f;
    public float FireRate3 = 0.2f;

    GameObject missile = null;
    public override void OnStart()
    {
        StartCoroutine(Enter());
        //StartCoroutine(FireMissile());
        //StartCoroutine(Fire2());
    }
    public override void OnUpdate()
    {
        this.ret2 = target.transform.position - this.gun2.transform.position;
        this.ret2.Normalize();// πÈ“ªªØ
        this.gun2.transform.rotation = Quaternion.FromToRotation(Vector3.right, ret2);
    }
    IEnumerator Enter()
    {
        this.transform.position = new Vector3(15, 0, 0);
        yield return MoveTo(new Vector3(5, 0, 0));
        yield return Attack();
    }

    IEnumerator Attack()
    {
        while(true)
        {
            Fire();
            Fire2();
            FireMissile();
            yield return null;
        }
    }

    IEnumerator MoveTo(Vector3 pos)
    {
        while(true)
        {
            Vector3 dir = (pos - this.transform.position);
            if (dir.magnitude < 0.1)
            {
                break;
            }
            this.transform.position += dir.normalized * Speed * Time.deltaTime;
            yield return null;
        }
    }
    private void FireMissile()
    {
        if (Time.time - this.fireTime3 > 1f / this.FireRate3)
        {
            this.animator.SetTrigger("RocketFire");
            this.fireTime3 = Time.time;
        }
    }

    private void Fire2()
    {
        if (Time.time - this.fireTime2 > 1f / this.FireRate2)
        {
            GameObject go = GameObject.Instantiate(bullet3, this.firePoint2.position, Quaternion.identity, null);
            Bullet3 bullet = go.GetComponent<Bullet3>();
            bullet.ret = this.ret2;
            this.fireTime2 = Time.time;
        }
        //while (true)
        //{
        //    yield return new WaitForSeconds(2f);
        //    GameObject go = GameObject.Instantiate(bullet3, this.firePoint2.position , Quaternion.identity, null);
        //    Bullet3 bullet = go.GetComponent<Bullet3>();
        //    bullet.ret = this.ret2;
        //}
    }

    public void OnMissileLoad()
    {
        missile = Instantiate(missileTemplate, firePoint3.position, Quaternion.identity);
        Rocket mc = missile.GetComponent<Rocket>();
        mc.target = this.target.transform;
    }

    public override void Dead()
    {
        this.animator.SetTrigger("BossDead");
        Destroy(this.gameObject, 0.2f);
    }

}
