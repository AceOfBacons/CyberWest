using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
    public Animator anim;
    private bool dead = false;
    public bool onCheck = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            LevelManager.instance.respawnPoint = collision.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Fire"))
        {
            //play sounds effect
            soundsManager.PlaySound("playerDeath");

            //trigger dead animation
            anim.SetBool("isDead", true);

            Invoke("deadSequence", 1.5f);
            Debug.Log("dead");
        }
        else
        {
            anim.SetBool("isDead", false);
        }
    }

    public void deadSequence()
    {
        Destroy(gameObject);
        LevelManager.instance.Respawn();
        Debug.Log("dead sequence trig");
    }
}
