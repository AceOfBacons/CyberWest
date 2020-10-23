using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsManager : MonoBehaviour
{
    public static AudioClip playerShootSound, jumpSound, deathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerShootSound = Resources.Load<AudioClip>("playerShootSound");
        jumpSound = Resources.Load<AudioClip>("playerJumpSound");

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
        }
    }
}
