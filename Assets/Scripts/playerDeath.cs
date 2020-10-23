using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
