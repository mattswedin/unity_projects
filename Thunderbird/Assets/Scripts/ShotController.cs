using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] int cameraIndex = 0;
    CameraController cameraController;

    void Awake() 
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    void OnEnable()
    {
        cameraController.SwitchToThisCamera(cameraIndex);
    }
}
