using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject bullettemplate;
    public Animator animator;
    public Transform firePoint1;
    public float FireRate = 10f;
    protected float fireTime = 0f;
    public float HP = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();

        OnStart();
    }
    void Update()
    {
        OnUpdate();
    }

    public virtual void OnStart()
    {
        
    }

    public virtual void OnUpdate()
    {

    }
    public virtual void Fire()
    {
        if (Time.time - this.fireTime > 1f / FireRate)
        {
            GameObject bullet = GameObject.Instantiate(bullettemplate);
            bullet.transform.position = this.firePoint1.position;
            this.fireTime = Time.time;
        }
    }


}
