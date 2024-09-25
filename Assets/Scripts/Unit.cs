using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject bullettemplate;
    public Animator animator;
    public float FireRate = 10f;
    public float fireTime = 0f;

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
    public void Fire()
    {
        if (Time.time - this.fireTime > 1f / FireRate)
        {
            GameObject bullet = GameObject.Instantiate(bullettemplate);
            bullet.transform.position = this.transform.position;
            this.fireTime = Time.time;
        }
    }
}
