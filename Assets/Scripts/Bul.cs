using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bul : MonoBehaviour
{
    public float speed = 15f;
    public DAMAGE_POWER power;
    void Start()
    {
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
}
