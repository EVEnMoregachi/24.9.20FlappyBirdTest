using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    public GameObject bullettemplate;
    private Animator animator;
    public float Speed = 10f;
    public float FireRate = 2f;
    private float fireTime = 0f;

    void Start()
    {
        Destroy(this.gameObject, 8f);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        this.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
        Fire();
    }


    private void Fire()
    {
        if (Time.time - this.fireTime > 1f / FireRate)
        {
            GameObject bullet = GameObject.Instantiate(bullettemplate);
            bullet.transform.position = this.transform.position;
            this.fireTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Dead");
            Destroy(this.gameObject, 0.2f);
        }
    }
}
