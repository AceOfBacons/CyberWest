using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    Vector3 lastVelocity;
    private Rigidbody2D clone2;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var Speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
        rb.velocity = direction * Speed;

        //if(other.gameObject.tag == "Ground")
        //{
        //    Destroy(rb, 2f);
        //}
    }

}
