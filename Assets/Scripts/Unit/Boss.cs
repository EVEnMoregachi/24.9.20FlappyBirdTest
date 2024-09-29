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
    public float rushCD = 15f;
    private float rushTimer = 0f;
    public float RushSpeed = 30f;
    public float MAX_HP = 500f;

    GameObject missile = null;
    public override void OnStart()
    {
        this.HP = this.MAX_HP;
        StartCoroutine(Enter());
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
            MoveToAim();
            Fire2();
            FireMissile();
            rushTimer += Time.deltaTime;
            if (this.HP < (this.MAX_HP / 2) && rushTimer > rushCD)
            {
                rushTimer = 0f;
                yield return RushAttack();
            }
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

    IEnumerator RushAttack()
    {
        yield return MoveTo(new Vector3(6f, target.position.y, 0));
        this.Speed = this.RushSpeed;
        yield return MoveTo(new Vector3(-15, this.transform.position.y, 0));
        this.Speed = 4f;
        this.transform.position = new Vector3(15, 0, 0);
        yield return MoveTo(new Vector3(5, 0, 0));
        this.Speed = 2f;
        yield return Attack();
    }

    private void FireMissile()
    {
        if (Time.time - this.fireTime3 > 1f / this.FireRate3)
        {
            this.animator.SetTrigger("RocketFire");
            this.fireTime3 = Time.time;
        }
    }

    public void MoveToAim()
    {
        if (firePoint1.position.y < target.position.y)
        {
            this.transform.position += Vector3.up * Time.deltaTime;
        }
        else if (firePoint1.position.y > target.position.y)
        {
            this.transform.position += Vector3.down * Time.deltaTime;
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
    }

    public void OnMissileLoad()
    {
        missile = Instantiate(missileTemplate, firePoint3.position, Quaternion.identity);
        Rocket mc = missile.GetComponent<Rocket>();
        mc.target = this.target.transform;
    }

    public override void Dead()
    {
        if (this.gameObject.name == "Boss(Clone)")
        {
            Game.Instance.GetPoint(50);
        }
        this.animator.SetTrigger("BossDead");
        Destroy(this.gameObject, 0.2f);
    }
}
