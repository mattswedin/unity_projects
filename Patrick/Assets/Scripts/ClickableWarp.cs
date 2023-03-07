using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableWarp : MonoBehaviour
{
    [SerializeField] string areaToWarp = "";
    [SerializeField] GameObject clickOverlay;
    [SerializeField] float actionDelay = 1;

    ZoomBlur zoomBlur;
    FadeToBlack fadeToBlack;
    GameStats gameStats;

    void Awake() 
    {
        gameStats = FindObjectOfType<GameStats>();
        zoomBlur = FindObjectOfType<ZoomBlur>();
        fadeToBlack = FindObjectOfType<FadeToBlack>();
    }

    private void Start() 
    {
        if (areaToWarp == "") areaToWarp = gameObject.name;
    }

    void OnMouseDown() 
    {
        if (gameStats.GetCanClick(gameObject.name))
        {
            if(areaToWarp != "") 
            {
                zoomBlur.SetZoomNow(true, gameObject.transform);
                StartCoroutine(Delay());
            }
            clickOverlay.SetActive(true);
        }
        
    }

    void OnMouseUp()
    {
        if (gameStats.GetCanClick(gameObject.name))
        {
            clickOverlay.SetActive(false);
        }
    }

    IEnumerator Delay() 
    {
        yield return new WaitForSeconds(actionDelay);
        SceneManager.LoadScene(areaToWarp);
    }
}
