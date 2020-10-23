using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D rb;
    public GameObject impactParticles;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(impactParticles, transform.position, transform.rotation);
        }

    }


}
