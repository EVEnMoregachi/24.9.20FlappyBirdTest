using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : Unit
{
    static public Player instance;
    private Rigidbody2D body;

    private void Awake()
    {
        instance = this;
    }
    public override void OnStart()
    {
        body = GetComponent<Rigidbody2D>();
        Idle();
    }

    public override void OnUpdate()
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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bul hurt = collision.GetComponent<Bul>();
            if (hurt != null)
            {
                this.HP -= (float)hurt.power;
                Game.instance.flashHP(this.HP);
                Destroy(hurt.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy hurt = collision.GetComponent<Enemy>();
            if (hurt != null)
            {
                this.HP -= (float)hurt.power;
                Game.instance.flashHP(this.HP);
            }
        }

    }
}
