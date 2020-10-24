using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsManager : MonoBehaviour
{
    public static AudioClip playerShootSound, jumpSound, deathSound, enemyShoot, enemyExplosion, playerDeath, playerWalk;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerShootSound = Resources.Load<AudioClip>("playerShootSound");
        jumpSound = Resources.Load<AudioClip>("playerJumpSound");
        enemyShoot = Resources.Load<AudioClip>("enemyShoot");
        enemyExplosion = Resources.Load<AudioClip>("enemyExplosion");
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerWalk = Resources.Load<AudioClip>("playerWalk");



        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerShootSound":
                audioSrc.PlayOneShot(playerShootSound);
                break;
            case "playerJumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "enemyShoot":
                audioSrc.PlayOneShot(enemyShoot);
                break;
            case "enemyExplosion":
                audioSrc.PlayOneShot(enemyExplosion);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath);
                break;
            case "playerWalk":
                audioSrc.loop = true;
                audioSrc.PlayOneShot(playerWalk);
                break;
        }
    }
}
