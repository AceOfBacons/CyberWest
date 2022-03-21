using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; // library

public class VirtualCameraController : MonoBehaviour
{
    public List<GameObject> virtualCameras;
    
    void Start()
    {
        virtualCameras.Clear(); // Clear in case there is something inside

        for (int i = 0; i < transform.childCount; i++)//iterate until it reaches amount of children the object has
        {
            virtualCameras.Add(transform.GetChild(i).gameObject);// grab all game objects and save them into virtualCameras
        }
    }

  public void TransitionTo(GameObject cameraToTransitionTo)
    {
        foreach (GameObject g in virtualCameras)
        {
            if (g == cameraToTransitionTo)
            {
                // transition to that camera
                g.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
            else
            {
                // Deprioritize camera
                g.GetComponent<CinemachineVirtualCamera>().Priority = 5;
            }
        }
    }
}
