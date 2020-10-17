using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public GameObject player;
    playerController playerController;
 
    void Start()
    {
        playerController = GetComponentInParent<playerController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.gameObject.CompareTag("Platform") && playerController.isG)
    }
}
