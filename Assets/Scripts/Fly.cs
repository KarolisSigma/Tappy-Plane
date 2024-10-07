using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private float jumpForce= 7;
    private Rigidbody2D rb;
    private Transform tr;
    private Quaternion rot;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = transform;
        rb.velocity=Vector2.zero;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && rb.velocity.y<0) {
            rb.velocity = Vector2.up*jumpForce;
        }
        tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(0,0,Mathf.Clamp(rb.velocity.y*5f, -50, 50)), Time.deltaTime*10f);

    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Ice")){
            Debug.Log("dead");
        }
    }
}
