using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static GameObject clone;
    private Animator anim;
    private bool isShooting = false;

    // Update is called once per frame
    public void Start()
    {
        clone = GetComponent<GameObject>();

    }
    void Update()
    {
        // Getting button and shooting
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            soundsManager.PlaySound("playerShootSound");
            Shoot();
            cinemachineShake.Instance.ShakeCamera(5f, .1f);
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
        anim.SetBool("shoot", isShooting);
    }

    public void Shoot()
    {
        // Instantiate bullets
        // Shooting logic
        clone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Spawn bullet at firepoint

    }

   
}


