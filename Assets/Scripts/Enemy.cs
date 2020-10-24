using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public float speed;
    //public float stoppinDistance;
    //public float retreatDistance;

    //[SerializeField] private float speed;
    [SerializeField] private bool shouldShoot;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] float fireRate;
    [SerializeField] public float deadzone = 3;
    private float fireCounter;
    public GameObject impactParticles;
    private Transform player;
    private bool isFacingRight;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    void Update()
    {
        if (Vector3.Distance(transform.position, playerController.instance.transform.position) < deadzone && playerController.instance.gameObject.activeInHierarchy)
        {
            fireCounter -= Time.deltaTime;
            if (fireCounter <= 0)
            {
                soundsManager.PlaySound("enemyShoot");
                fireCounter = fireRate;
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            }
        }


        //if (Vector2.Distance(transform.position, player.position) > stoppinDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        //}
        //else if (Vector2.Distance(transform.position, player.position) < stoppinDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        //{
        //    transform.position = this.transform.position;

        //}
        //else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        //{
        //    Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}


    }

}
