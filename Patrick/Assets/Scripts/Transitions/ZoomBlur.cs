using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomBlur : MonoBehaviour
{
    Vector3 objPos;
    Vector2 worldPos;
    Vector3 worldScale;
    GameObject environment;
    [SerializeField] GameObject cutToBlack;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float zoomSpeed = 1.5f;
    [SerializeField] float amountToZoom = 3;
    [SerializeField] bool zoomNow;

    FadeToBlack fadeToBlack;
    
    void Start()
    {

        environment = GameObject.Find("Environment");
    }

    void Update() 
    {
        if (zoomNow) 
        {
            ZoomBlurTransition();
        }
    }

    public void SetZoomNow(bool state, Transform pos) 
    {
        objPos = pos.position;
        zoomNow = state;
    }

    void ZoomBlurTransition() 
    {
        environment.transform.position = Vector2.MoveTowards(environment.transform.position, -objPos, moveSpeed * Time.deltaTime);

        environment.transform.localScale = Vector3.MoveTowards(environment.transform.localScale, new Vector3(amountToZoom, amountToZoom, amountToZoom), zoomSpeed * Time.deltaTime);


        if (environment.transform.position == -objPos)
        {
            if (cutToBlack != null)
            {
                cutToBlack.SetActive(true);
            }
        }
    }

}
