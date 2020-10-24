using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float shootDelay;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static GameObject clone;
    private Animator anim;
    private bool isShooting = false;

    // Update is called once per frame
    public void Start()
    {
        clone = GetComponent<GameObject>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        shootDelay -= Time.deltaTime;
        // Getting button and shooting
        if (Input.GetButtonDown("Fire1"))
        {
            if(shootDelay <= 0)
            {
                soundsManager.PlaySound("playerShootSound");
                Shoot();
                cinemachineShake.Instance.ShakeCamera(5f, .1f);
                anim.SetBool("shoot", true);
                shootDelay = .5f;
            }
            

        }
        else if(Input.GetKeyUp("space"))
        {
            anim.SetBool("shoot", false);
        }

    }

    public void Shoot()
    {
        // Instantiate bullets
        // Shooting logic
        clone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Spawn bullet at firepoint

    }

   
}


