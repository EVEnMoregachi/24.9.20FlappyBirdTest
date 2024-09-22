using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    static public Player instance;
    private Rigidbody2D body;
    private Animator animator;
    public float Speed = 5f;
    public GameObject bullettemplate;
    public float FireRate = 10f;
    private float fireTime = 0f;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Idle();
    }

    void Update()
    {
        if (Game.instance.status == Game.GAME_STATUS.Running)
        {
            //body.velocity = Vector2.zero;
            //body.AddForce(new Vector2(0, force));
            //animator.SetTrigger("Fly");

            animator.SetTrigger("Fly");
            animator.applyRootMotion = true;

            Vector2 pos = this.transform.position;
            pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            pos.y += Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            this.transform.position = pos;

            if (Input.GetButton("Fire1"))
            {
                Fire();
            }
        }
    }

    private void Idle()
    {
        animator.applyRootMotion = false;
        body.Sleep();

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
    public void Fly()
    {
        //animator.applyRootMotion = true;
        //body.WakeUp();
        //animator.SetTrigger("Fly");
        //body.velocity = Vector2.zero;
        //body.AddForce(new Vector2(0, force));

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
            Game.instance.Damage(10f);
        }


    }
}
