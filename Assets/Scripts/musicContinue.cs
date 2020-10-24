using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicContinue : MonoBehaviour
{
    private void Awake()
    {
        //Keep on playing music on load
        DontDestroyOnLoad(transform.gameObject);
    }
}
