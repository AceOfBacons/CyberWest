//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Enemy : MonoBehaviour
//{
//    public float speed;
//    public float stoppinDistance;
//    public float retreatDistance;

//    private Transform player;

//    void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//    }


//    void Update()
//    {
//        if (Vector2.Distance(transform.position, player.position) > stoppinDistance)
//        {
//            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

//        } 
//        else if (Vector2.Distance(transform.position, player.position) < stoppinDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
//        {
//            transform.position = this.transform.position;

//        } 
//        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
//        {
//            Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
//        }
 
        
//    }
//}
