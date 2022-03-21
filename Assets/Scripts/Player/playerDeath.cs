using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
    public Animator anim;
    private bool dead = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Fire"))
        {
            soundsManager.PlaySound("playerDeath");
            anim.SetBool("isDead", true);
            Invoke("deadSequence", 1.5f);
            Debug.Log("dead");
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
        LevelManager.instance.Respawn();
        Debug.Log("dead sequence trig");
    }
}
