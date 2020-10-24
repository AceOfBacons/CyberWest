using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    public Animator anim;
    private bool dead = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            soundsManager.PlaySound("enemyExplosion");
            anim.SetBool("isDead", true);
            Invoke("deadSequence", 1.0f);
            Debug.Log("dead enemy");
        }
        else
        {
            anim.SetBool("isDead", false);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void deadSequence()
    {
        Destroy(gameObject);
        Debug.Log("sequence");
    }
}

