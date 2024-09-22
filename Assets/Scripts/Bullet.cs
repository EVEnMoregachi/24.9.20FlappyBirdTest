using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
