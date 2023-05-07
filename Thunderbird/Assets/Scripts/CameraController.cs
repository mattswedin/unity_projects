using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera rigCamera;
    [SerializeField] Camera[] cams;
    Camera main;
    int camNum;

    void Start()
    {
        rigCamera.enabled = true;
        main = rigCamera;

        foreach (Camera cam in cams) 
        {
            cam.enabled = false;
        }
        
    }

    public void SwitchToThisCamera(int camIndex) 
    {
        Debug.Log("Attempting to switch cameras...");
        if (main == rigCamera) 
        {
            main.enabled = false;
            rigCamera.enabled = false;
            cams[camIndex].enabled = true;
            main = cams[camIndex];
            camNum = camIndex;
            main.fieldOfView = 36.1f;
        }
        else
        {
            main.enabled = false;
            cams[camNum].enabled = false;
            cams[camIndex].enabled = true;
            main = cams[camIndex];
            camNum = camIndex;
        }

    }

    // Camera Index
    // Cam 1 : Long Shot Before Cutscene
}
