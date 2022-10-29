using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableObject : MonoBehaviour
{
    [SerializeField] string areaToWarp = "";
    [SerializeField] GameObject clickOverlay;
    [SerializeField] float actionDelay = 1;

    ZoomBlur zoomBlur;
    FadeToBlack fadeToBlack;

    void Awake() 
    {
        zoomBlur = FindObjectOfType<ZoomBlur>();
        fadeToBlack = FindObjectOfType<FadeToBlack>();
    }

    void OnMouseDown() 
    {
        if(areaToWarp != "") 
        {
            zoomBlur.SetZoomNow(true, gameObject.transform);
            StartCoroutine(Delay());
        }
        clickOverlay.SetActive(true);
    }

    void OnMouseUp()
    {
        clickOverlay.SetActive(false);
    }

    IEnumerator Delay() 
    {
        yield return new WaitForSeconds(actionDelay);
        SceneManager.LoadScene(areaToWarp);
    }
}
