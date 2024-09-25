using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject missileTemplate;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform target;

    GameObject missile = null;
    public override void OnStart()
    {
        StartCoroutine(FireMissile());
    }
    public override void OnUpdate()
    {
        
    }

    IEnumerator FireMissile()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            this.animator.SetTrigger("RocketFire");
        }
    }

    public void OnMissileLoad()
    {
        missile = Instantiate(missileTemplate, firePoint3.position, Quaternion.identity);
        Rocket mc = missile.GetComponent<Rocket>();
        mc.target = this.target.transform;
    }

}
