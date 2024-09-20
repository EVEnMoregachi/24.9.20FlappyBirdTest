using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;
    private Rigidbody2D body;
    private Animator animator;
    public float force = 300f;
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
        if (Input.GetMouseButtonDown(0) && Game.instance.status == Game.GAME_STATUS.Running)
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0, force));
            animator.SetTrigger("Fly");
        }
    }

    private void Idle()
    {
        animator.applyRootMotion = false;
        body.Sleep();
        animator.SetTrigger("Idle");

    }
    public void Fly()
    {
        animator.applyRootMotion = true;
        body.WakeUp();
        animator.SetTrigger("Fly");
        body.velocity = Vector2.zero;
        body.AddForce(new Vector2(0, force));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            Game.instance.GetPoint();
        }
        else
        {
            Game.instance.GameOver();
        }
    }
}
